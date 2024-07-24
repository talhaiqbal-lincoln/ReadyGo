using AutoMapper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ReadyGo.Domain.Constants;
using ReadyGo.Domain.Entities;
using ReadyGo.Domain.Entities.ApiModels;
using ReadyGo.Domain.Entities.Identity;
using ReadyGo.Domain.Enum;
using ReadyGo.Persistence.Seeds;
using ReadyGo.Service.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReadyGo.Web.Controllers.API
{
    [ApiController]
    [ApiVersion("1.0")]
    [ApiExplorerSettings(GroupName = "mobile")]
    [Route("api/v{version:apiVersion}/SpInfo/")]
    public class SpInfoController : BaseApiController
    {
        private readonly IMapper _mapper;
        private readonly IGenericRepository<DeliveryReport> _reportRepo;
        private readonly IGenericRepository<Configuration> _configRepo;
        private readonly IGenericRepository<ResourceFile> _filesRepo;
        private readonly UserManager<ApplicationUser> _userManager;

        public SpInfoController(IMapper mapper, UserManager<ApplicationUser> userManager, IGenericRepository<DeliveryReport> reportRepo,
            IGenericRepository<Configuration> configRepo, IGenericRepository<ResourceFile> filesRepo)
        {
            _mapper = mapper;
            _reportRepo = reportRepo;
            _configRepo = configRepo;
            _filesRepo = filesRepo;
            _userManager = userManager;
        }

        /// <summary>
        /// Get method for Saleperson data
        /// </summary>
        /// <returns></returns>
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [HttpGet]
        [Route("GetSpInfo")]
        public IActionResult GetSpInfo()
        {
            try
            {
                SalePersonInfoApiViewModel responseViewModel = new SalePersonInfoApiViewModel();

                var email = DecodeJwt();
                var user = _userManager.Users.Include(x => x.Routes.Where(x => x.DeletedAt == null)).ThenInclude(x => x.Route)
                    .Include(x => x.ProfileImage).AsNoTracking()
                    .FirstOrDefault(x => x.Email.Equals(email));

                if (!user.IsActive)
                {
                    return Forbid();
                }

                var userViewModel = _mapper.Map<UserApiViewModel>(user);

                var activePermanentRoute = user.Routes.Where(x => !x.TemporaryAssignedTill.HasValue && x.Route.DeletedAt == null && x.Route.IsActive).FirstOrDefault();

                var activetemporaryRoute = user.Routes.FirstOrDefault(x => x.TemporaryAssignedTill.HasValue && x.TemporaryAssignedTill.Value.Date >= DateTime.Today.Date
                                && x.Route.DeletedAt == null && x.Route.IsActive);


                var lastSentReport = _reportRepo.FindAll(x => x.SalesPersonId.Equals(user.Id) && x. DeletedAt == null)
                                    .Include(x=> x.Vehicle).Include(x => x.Route).OrderByDescending(x => x.CreatedAt).FirstOrDefault();


                var thrashHold = _configRepo.FindAll(x => x.ConfigKey == "SalesManager_DiscountThrashHold" || x.ConfigKey == "TermsConditions").ToList();
                var SmDiscount = thrashHold?.Where(x => x.ConfigKey == "SalesManager_DiscountThrashHold").Select(x => x.Value).FirstOrDefault();
                var termCondition = thrashHold?.Where(x => x.ConfigKey == "TermsConditions").Select(x => x.Value).FirstOrDefault();

                responseViewModel.Id = userViewModel.Id;
                responseViewModel.UserName = userViewModel.UserName;
                responseViewModel.Email = userViewModel.Email;
                responseViewModel.Image = userViewModel.Image;
                responseViewModel.SaleManagerDiscount = !string.IsNullOrWhiteSpace(SmDiscount)? Convert.ToDouble(SmDiscount) : 0;
                responseViewModel.TermsConditions = termCondition;
                if (activePermanentRoute != null)
                {
                    responseViewModel.RouteId = activePermanentRoute.RouteId;
                    responseViewModel.RouteName = activePermanentRoute.Route.Name;
                }

                if (activetemporaryRoute != null)
                {
                    responseViewModel.TemporyRouteId = activetemporaryRoute.RouteId;
                    responseViewModel.TemporyRouteName = activetemporaryRoute.Route.Name;
                }


                if (lastSentReport != null)
                {
                    responseViewModel.LastDeliveryReportData = lastSentReport.CreatedAt;
                    responseViewModel.DriverName = lastSentReport.DriverName;
                    responseViewModel.VehicleNo = lastSentReport.Vehicle?.VehicleNumber;
                    responseViewModel.DeliveryReportRouteName = lastSentReport.Route?.Name;
                }
                var responseData = new
                {
                    SpInfo = responseViewModel
                };
                return Ok(new ApiResponseModel(responseData));


            }
            catch (Exception ex)
            {
                return BadRequest(new ApiResponseModel(ApiStatus.Error, ApiErrors.DefaultError.GetDescription(), ApiErrors.DefaultError));
            }
        }
        /// <summary>
        /// Post method for update sale person profile pic
        /// </summary>
        /// <param name="apiViewModel">User's profile picture</param>
        /// <returns></returns>
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [HttpPost]
        [Route("UpdateProfilePicture")]
        public async Task<IActionResult> UpdateSpPicture(SalePersonInfoApiViewModel apiViewModel)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(new ApiResponseModel(ApiStatus.Error, ApiErrors.ModelState.GetDescription(), ApiErrors.ModelState));
                }
                var email = DecodeJwt();
                Object responseData = null;
                //Get Details of sale person who requested to add customer
                var curUser = _userManager.Users.Include(x => x.ProfileImage).FirstOrDefault(x => x.Email.Equals(email));

                if (!curUser.IsActive)
                {
                    return Forbid();
                }

                if (!string.IsNullOrWhiteSpace(apiViewModel.Image) && IsBase64String(apiViewModel.Image))
                {
                    var image = Convert.FromBase64String(apiViewModel.Image);
                    if (curUser.ProfileImage != null)
                    {
                        curUser.ProfileImage.File = image;
                    }
                    else
                    {
                        ResourceFile userImage = new ResourceFile()
                        {
                            File = image,
                            Name = "pp_" + curUser.Id.ToString() + GetFileExtension(apiViewModel.Image),
                            MimeType = "Image"
                        };
                        _filesRepo.Insert(userImage);
                        curUser.ProfileImageId = userImage.Id;
                    }
                    await _userManager.UpdateAsync(curUser);
                    return Ok(new ApiResponseModel(responseData));
                }
                else
                {
                    return BadRequest(new ApiResponseModel(ApiStatus.Error, ApiErrors.DefaultError.GetDescription(), ApiErrors.DefaultError));
                }
            }
            catch (Exception ex)
            {
                return BadRequest(new ApiResponseModel(ApiStatus.Error, ApiErrors.DefaultError.GetDescription(), ApiErrors.DefaultError));
            }
        }

        #region Helper Methods
        [NonAction]
        private bool IsBase64String(string base64)
        {
            Span<byte> buffer = new Span<byte>(new byte[base64.Length]);
            return Convert.TryFromBase64String(base64, buffer, out int bytesParsed);
        }

        [NonAction]
        private string GetFileExtension(string base64String)
        {
            var data = base64String.Substring(0, 5);

            switch (data.ToUpper())
            {
                case "IVBOR":
                    return ".png";
                case "/9J/4":
                    return ".jpg";
                case "AAAAF":
                    return ".mp4";
                case "JVBER":
                    return ".pdf";
                case "AAABA":
                    return ".ico";
                case "UMFYI":
                    return ".rar";
                case "E1XYD":
                    return ".rtf";
                case "U1PKC":
                    return ".txt";
                case "MQOWM":
                case "77U/M":
                    return ".srt";
                default:
                    return string.Empty;
            }
        }
        #endregion
    }
}
