using AutoMapper;
using LINQtoCSV;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ReadyGo.Domain.Constants;
using ReadyGo.Domain.Entities.Identity;
using ReadyGo.Domain.Entities.ViewModels;
using ReadyGo.Domain.Enum;
using ReadyGo.Infrastructure.Extension;
using ReadyGo.Infrastructure.Filters;
using ReadyGo.Infrastructure.ViewModel;
using ReadyGo.Persistence.Seeds;
using ReadyGo.Service.Interfaces;
using ReadyGo.Service.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ReadyGo.Domain.Entities;
using System.Globalization;
using System.Diagnostics;
using System.Net.Mail;
using System.Net;
using System.Text;

namespace ReadyGo.Web.Controllers
{
    /// <summary>
    /// Class related to User Management including User listing, addition, editing, and details
    /// </summary>
    [Authorize]
    [TypeFilter(typeof(AdminAccessFilter))]
    public class UserController : BaseController
    {
        private readonly IMapper _mapper;
        private readonly IValidationHelper _validationHelper;
        private readonly IGenericRepository<ApplicationRole> _rolesRepo;
        private readonly IGenericRepository<ApplicationUser> _userRepo;
        private readonly IGenericRepository<AssignedRoute> _assignedRoute;
        private readonly IGenericRepository<EmailSettings> _mailSettings;

        public UserController(IMapper mapper, IValidationHelper validationHelper,
            IGenericRepository<ApplicationRole> rolesRepo, 
            IGenericRepository<ApplicationUser> userRepo,
            IGenericRepository<AssignedRoute> assignedRoute,
            IGenericRepository<EmailSettings> mailSettings)
        {
            _userRepo = userRepo;
            _rolesRepo = rolesRepo;
            _mapper = mapper;
            _validationHelper = validationHelper;
            _assignedRoute = assignedRoute;
            _mailSettings = mailSettings;
        }

        // GET: UserController
        public ActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// Method to retrieve users list for datatable
        /// </summary>
        /// <returns>Users in the form of Json</returns>
        [HttpPost]
        public IActionResult AllUsers()
        {
            string currentUserGuid = User.Claims.First().Value;
            try
            {
                var draw = Request.Form["draw"].FirstOrDefault();
                var status = Request.Form["status"].FirstOrDefault();
                var activeStatus = Request.Form["activeStatus"].FirstOrDefault();
                var start = Request.Form["start"].FirstOrDefault();
                var length = Request.Form["length"].FirstOrDefault();
                var sortColumn = Request.Form["order[0][column]"].FirstOrDefault();
                var sortColumnDirection = Request.Form["order[0][dir]"].FirstOrDefault();
                var searchValue = Request.Form["search[value]"].FirstOrDefault()?.Trim().Trim() ?? "";
                var flag = Request.Form["flag"].FirstOrDefault();
                int pageSize = Convert.ToInt32(length ?? "0");
                int skip = Convert.ToInt32(start ?? "0");
                int recordsTotal = 0;

                var userData = _userManager.Users.
                    Include(x=>x.ProfileImage).Include(x=>x.Role).
                    Where(x => x.DeletedAt == null && x.EmailConfirmed).ToList();

                if (status == "Synced")
                    userData = userData.Where(x => x.SyncedAt != null).ToList();
                else if (status == "UnSynced")
                    userData = userData.Where(x => x.SyncedAt == null).ToList();
                if (activeStatus == "Active")
                    userData = userData.Where(x => x.IsActive).ToList();
                else if (activeStatus == "InActive")
                    userData = userData.Where(x => !x.IsActive).ToList();

                var users = userData.Select(x => new UserTableViewModel
                {
                    AxCode = x.AxCode, 
                    IsActive = x.IsActive,
                    UserRole = x.Role.NormalizedName,
                    PhoneNumber = x.PhoneNumber,
                    ProfileImage = x.ProfileImage != null ? "data:image;base64," + Convert.ToBase64String(x.ProfileImage.File) : "/resource_files/default_user.jpg",
                    Id = x.Id,
                    Email = x.Email,
                    FirstName = x.FirstName,
                    LastName = x.LastName,
                    IsCurrentUser = x.Id == currentUserGuid,
                    SyncedStatus = x.SyncedAt != null
                });

                users = flag == "All Roles" ? users :
                  users.Where(u => u.UserRole == flag);

                if (!(string.IsNullOrEmpty(sortColumn) && string.IsNullOrEmpty(sortColumnDirection)))
                {
                    int column = Int32.Parse(sortColumn);
                    switch (column)
                    {
                        case 1:
                            users = sortColumnDirection == "asc" ? users.OrderBy(c => c.AxCode) :
                                users.OrderByDescending(c => c.AxCode);
                            break;

                        case 2:
                            users = sortColumnDirection == "asc" ? users.OrderBy(c => c.FirstName) :
                                users.OrderByDescending(c => c.FirstName);
                            break;

                        case 3:
                            users = sortColumnDirection == "asc" ? users.OrderBy(c => c.LastName) :
                                users.OrderByDescending(c => c.LastName);
                            break;

                        case 4:
                            users = sortColumnDirection == "asc" ? users.OrderBy(c => c.PhoneNumber) :
                                users.OrderByDescending(c => c.PhoneNumber);
                            break;

                        case 5:
                            users = sortColumnDirection == "asc" ? users.OrderBy(c => c.Email) :
                                users.OrderByDescending(c => c.Email);
                            break;
                    }
                }
                if (!string.IsNullOrEmpty(searchValue))
                {
                    users = users.Where(m => m.FirstName.ToLower().Contains(searchValue.ToLower())
                                        || (m.LastName != null && m.LastName.ToLower().Contains(searchValue.ToLower()))
                                        || (!string.IsNullOrEmpty(m.AxCode) && m.AxCode.Contains(searchValue, StringComparison.OrdinalIgnoreCase))
                                        || m.PhoneNumber.Contains(searchValue)
                                        || m.Email.ToLower().Contains(searchValue.ToLower()));
                }
                recordsTotal = users.Count();
                var data = users.Skip(skip).Take(pageSize).ToList();

                return Json(new { draw, recordsFiltered = recordsTotal, recordsTotal, data });
            }
            catch (Exception ex)
            {
                LogException(ex);
                return null;
            }
        }
        public ActionResult Invite()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AllInvites()
        {
            try
            {
                var draw = Request.Form["draw"].FirstOrDefault();
                var start = Request.Form["start"].FirstOrDefault();
                var length = Request.Form["length"].FirstOrDefault();
                var status = Request.Form["status"].FirstOrDefault();
                var sortColumn = Request.Form["order[0][column]"].FirstOrDefault();
                var sortColumnDirection = Request.Form["order[0][dir]"].FirstOrDefault();
                var searchValue = Request.Form["search"].FirstOrDefault().Trim();
                var flag = Request.Form["flag"].FirstOrDefault();
                int pageSize = Convert.ToInt32(length ?? "0");
                int skip = Convert.ToInt32(start ?? "0");
                int recordsTotal = 0;

                var userData1 = _userManager.Users.
                    Include(x=>x.ProfileImage).Include(x=>x.Role).
                    Where(x => x.DeletedAt == null && !x.EmailConfirmed);

                var userData = _mapper.Map<List<InviteTableViewModel>>(userData1);

                userData = flag == "All Roles" ? userData :
                  userData.Where(u => u.UserRole == flag).ToList();

                if (!(string.IsNullOrEmpty(sortColumn) && string.IsNullOrEmpty(sortColumnDirection)))
                {
                    int column = Int32.Parse(sortColumn);
                    switch (column)
                    {
                        case 1:
                            userData = sortColumnDirection == "asc" ? userData.OrderBy(c => c.FirstName).ToList() : 
                                userData.OrderByDescending(c => c.FirstName).ToList();
                            break;

                        case 2:
                            userData = sortColumnDirection == "asc" ? userData.OrderBy(c => c.LastName).ToList()
                                : userData.OrderByDescending(c => c.LastName).ToList();
                            break;

                        case 3:
                            userData = sortColumnDirection == "asc" ? userData.OrderBy(c => c.Email).ToList() : userData.OrderByDescending(c => c.Email).ToList();
                            break;

                        case 5:
                            userData = sortColumnDirection == "asc" ? userData.OrderByDescending(c => c.TimeFlag).ThenBy(x => x.FirstName).ToList() :
                                userData.OrderBy(c => c.TimeFlag).ThenBy(x => x.FirstName).ToList();
                            break;
                    }
                }
                userData = status.Equals("Pending") ?
                    userData.Where(x => x.InviteTime >= DateTime.Now.AddDays(-1)).ToList() : status.Equals("Expired") ?
                    userData.Where(x => x.InviteTime < DateTime.Now.AddDays(-1)).ToList() :
                    userData;

                if (!string.IsNullOrEmpty(searchValue))
                {
                    userData = userData.Where(m => !string.IsNullOrEmpty(m.FirstName) && m.FirstName.ToLower().Contains(searchValue.ToLower())
                                        || !string.IsNullOrEmpty(m.LastName) && m.LastName.ToLower().Contains(searchValue.ToLower())
                                        || m.Email.ToLower().Contains(searchValue.ToLower())).ToList();
                }
                recordsTotal = userData.Count();
                var data = userData.Skip(skip).Take(pageSize).ToList();

                return Json(new { draw, recordsFiltered = recordsTotal, recordsTotal, data });
            }
            catch (Exception ex)
            {
                LogException(ex);
                throw;
            }
        }

        /// <summary>
        /// Method to delete user
        /// </summary>
        /// <param name="id">Id of the user to be deleted</param>
        /// <returns>Status code based on deletion success or failure</returns>
        /// <response code="200">Returns success message</response>
        /// <response code="500">Returns exception in message</response>
        [HttpPost]
        // Delete

        public async Task<IActionResult> DeleteUserAsync(string id)
        {
            try
            {
                var user = await _userManager.FindByIdAsync(id);
                user.DeletedAt = DateTime.Now;
                await _userManager.UpdateAsync(user);
                var routes = _assignedRoute.FindAll(x => x.SalesPersonId.Equals(user.Id)).ToList();
                _assignedRoute.DeleteRange(routes);
                await AddLogAsync(LogActions.Delete.GetDescription(), user.UserName, LogsActionSrc.UserManagement.ToString());
                return Ok(new
                {
                    Message = string.Format(SuccessMessageConstants.DeleteSuccess, "User")
                });
            }
            catch (Exception ex)
            {
                LogException(ex);
                return BadRequest(
                   new
                   {
                       ErrorMessageConstants.Error
                   });
            }
        }

        /// <summary>
        /// Get method to fetch user to be updated
        /// </summary>
        /// <param name="id">id of the user</param>
        /// <returns>Object of the user</returns>
        [HttpGet]
        public IActionResult UpdateUser(string id, string flag)
        {
            var user = _userManager.Users.Include(x => x.Role).Include(x => x.ProfileImage).First(x => x.Id.Equals(id));
            ViewBag.EmailConfirmed = user.EmailConfirmed == false ? null : "readonly";
            ViewBag.Action = "EditUser";
            ViewBag.PageTitle = "Edit User";
            ViewBag.Editable = true;
            if (flag.Equals("readonly"))
            {
                ViewBag.PageTitle = "User Details";
                ViewBag.Editable = false;
            }
            try
            {
                ViewBag.Roles = _rolesRepo.FindAll(x => !x.Name.Equals(Roles.Admin.ToString())).Select(x => new {
                    x.Id,
                    Role = x.Name
                }).OrderByDescending(x=>x.Role);
                var userViewModel = _mapper.Map<UserViewModel>(user);
                if (Roles.Admin.GetDescription() == user.Role.Name)
                    userViewModel.RoleType = Roles.Admin;
                else if (Roles.SalesPerson.GetDescription() == user.Role.Name)
                    userViewModel.RoleType = Roles.SalesPerson;
                else if (Roles.SalesManager.GetDescription() == user.Role.Name)
                    userViewModel.RoleType = Roles.SalesManager;
                else if (Roles.MarketingManager.GetDescription() == user.Role.Name)
                    userViewModel.RoleType = Roles.MarketingManager;
                userViewModel.UserRole = user.Role.Name;
               
                //return PartialView("_AddUser", userViewModel);
                return View("AddUser", userViewModel);
            }
            catch (Exception ex)
            {
                LogException(ex);
                ViewBag.Message = ex.Message;
                return PartialView("_AddUser");
            }
        }

        /// <summary>
        /// Post method for user updation
        /// </summary>
        /// <param name="user">Updated user info</param>
        /// <returns>Status codes based on updation success/failure</returns>
        /// <response code="200">Returns success message</response>
        /// <response code="500">Returns exception in message</response>
        [HttpPost]
        [ModelValidationFilter]
        public async Task<IActionResult> UpdateUserAsync(UserViewModel user, IFormFile file)
        {
            try
            {
                user.Email = user.Email.Trim().ToLower();

                ApplicationUser appUser = _userManager.Users.Include(x=>x.ProfileImage).First(x=>x.Id.Equals(user.Id));

                if (appUser.RoleId != AppConstants.Admin)
                    user.RoleId = user.RoleId;
                else
                    user.RoleId = new Guid(appUser.RoleId);

                _mapper.Map<UserViewModel, ApplicationUser>(user, appUser);
                appUser = HandleImage(file, appUser);
                user.ProfileImage = appUser.ProfileImage;
                await _userManager.UpdateAsync(appUser);
                await AddLogAsync(LogActions.Update.GetDescription(), appUser.UserName, LogsActionSrc.UserManagement.ToString());
                return Ok(
                    new
                    {
                        Message = string.Format(SuccessMessageConstants.UpdateSuccess, "User")
                    });
            }
            catch (Exception ex)
            {
                LogException(ex);
                return BadRequest(
                   new
                   {
                       ex.Message
                   });
            }
        }

        /// <summary>
        /// Get method that specifies the view about add action
        /// </summary>
        /// <returns>partial view to be added in modal</returns>
        [HttpGet]
        public IActionResult AddUser()
        {
            //UserViewModel model = new UserViewModel();
            //ViewData["Controller"] = "Account";
            //ViewData["Action"] = "AddUser";
            //return PartialView("_AddUser", model);
            ViewBag.Action = "AddUser";
            ViewBag.PageTitle = "Add User";
            ViewBag.Editable = true;
            ViewBag.Roles = _rolesRepo.FindAll(x => !x.Name.Equals(Roles.Admin.ToString())).Select(x => new {
                x.Id,
                Role = x.Name
            }).OrderByDescending(x => x.Role);
            UserViewModel model = new UserViewModel();
            return View(model);
        }

        /// <summary>
        /// post method to add user
        /// </summary>
        /// <param name="model">User to be added</param>
        /// <returns>Status codes based on addition's success or failure</returns>
        /// <response code="200">Returns success message</response>
        /// <response code="500">Returns exception in message</response>
        [HttpPost]
        [ModelValidationFilter]
        public async Task<IActionResult> AddUser(UserViewModel model, IFormFile file)
        {
            model.Email = model.Email.Trim().ToLower();

            try
            {
                ApplicationUser appUser = await _userManager.FindByEmailAsync(model.Email.ToLower());

                if (appUser != null)
                {
                    if (appUser.DeletedAt != null)
                    {
                        return Conflict(new
                        {
                            Message = QuestionMessageConstants.ReAdd + appUser.UserName + "?",
                            userId = appUser.Id
                        });
                    }
                    else
                    {
                        return BadRequest(new
                        {
                            Message = string.Format(ErrorMessageConstants.AlreadyExists, "User")
                        });
                    }
                }
                else
                {
                    model.RoleId = new Guid(GetRoleId(model.RoleType));
                    var user = _mapper.Map<ApplicationUser>(model);
                    user.InviteTime = DateTime.Now;
                    user = HandleImage(file, user);
                    //if (model.RoleType == Roles.SalesPerson)
                    //    user.AxCode = "Emp-" + new Random().Next(1000, 9999);
                    var result = await _userManager.CreateAsync(user);
                    if (result.Succeeded)
                    {
                        await AddLogAsync(LogActions.Add.GetDescription(), user.Email, LogsActionSrc.UserManagement.ToString());
                        await InviteUser(user, user.Email, new EmailRequest(), true);
                        return Ok(new
                        {
                            Message = string.Format(SuccessMessageConstants.CreateSuccess, "User")
                        });
                    }
                    return BadRequest(new
                    {
                        Message = string.Format(ErrorMessageConstants.CreateFail, "User")
                    });
                }
            }
            catch (Exception ex)
            {
                LogException(ex);
                return BadRequest(new
                {
                    Message = string.Format(ErrorMessageConstants.CreateFail, "User")
                });
            }
        }

        /// <summary>
        /// For resending invite to the user that has already been added
        /// </summary>
        /// <param name="id">Id of the user to be invited</param>
        /// <returns>Status Codes</returns>
        /// <response code="200">Returns success message</response>
        /// <response code="500">Returns exception in message</response>
        [HttpPost]
        public async Task<IActionResult> SendInvite(string email)
        {
            try
            {
                var user = await _userManager.FindByEmailAsync(email);
                if (await InviteUser(user, email, new EmailRequest(), true))
                {
                    return Ok(new
                    {
                        Message = EmailConstants.SendSuccess
                    });
                }
                else
                {
                    return BadRequest(new
                    {
                        Message = EmailConstants.SendFail
                    });
                }
            }
            catch (Exception ex)
            {
                LogException(ex);
                return BadRequest(new
                {
                    Message = EmailConstants.SendFail
                });
            }
        }

        /// <summary>
        /// Method to deactivate or activate user
        /// </summary>
        /// <param name="id">Id of the user to be activated/deactivated</param>
        /// <returns>Status codes based on success/failure</returns>
        /// <response code="200">Returns success message</response>
        /// <response code="500">Returns exception in message</response>
        [HttpGet]
        public async Task<IActionResult> ChangeStatus(string id)
        {
            try
            {
                var user = await _userManager.FindByIdAsync(id);
                user.IsActive = !user.IsActive;
                await _userManager.UpdateAsync(user);
                var routes = _assignedRoute.FindAll(x => x.SalesPersonId.Equals(user.Id)).ToList();
                _assignedRoute.DeleteRange(routes);
                var Message = string.Empty;
                await AddLogAsync(LogActions.ChangeStatus.GetDescription(), user.UserName, LogsActionSrc.UserManagement.ToString());
                if (user.IsActive)
                {
                    Message = string.Format(SuccessMessageConstants.UserActiveSuccess, "User");
                }
                else
                {
                    Message = string.Format(SuccessMessageConstants.UserInactiveSuccess, "User");
                }
                return Ok(new { Message });
            }
            catch (Exception ex)
            {
                LogException(ex);
                return BadRequest(new
                {
                    Message = ErrorMessageConstants.Error
                });
            }
        }

        /// <summary>
        /// To undo a delete
        /// </summary>
        /// <param name="id">id of the user to re-add</param>
        /// <returns>Status codes based on success/failure</returns>
        /// <response code="200">Returns success message</response>
        /// <response code="500">Returns exception in message</response>
        [HttpPost]
        public async Task<IActionResult> UndoDelete(string id)
        {
            try
            {
                var user = await _userManager.FindByIdAsync(id);
                user.DeletedAt = null;
                await _userManager.UpdateAsync(user);
                await AddLogAsync(LogActions.ReActivate.GetDescription(), user.UserName, LogsActionSrc.UserManagement.ToString());
                return Ok(new
                {
                    Message = string.Format(SuccessMessageConstants.ReAddSuccess, "User")
                });
            }
            catch (Exception ex)
            {
                LogException(ex);
                return BadRequest(new
                {
                    Message = ErrorMessageConstants.Error
                });
            }
        }

        /// <summary>
        /// Reset Password Link
        /// </summary>
        /// <param name="id">id of the user to send reset password link</param>
        /// <returns>Status codes based on success/failure</returns>
        /// <response code="200">Returns success message</response>
        /// <response code="500">Returns exception in message</response>
        [HttpPost]
        public async Task<IActionResult> SendResetLink(string id)
        {
            try
            {
                if (!string.IsNullOrEmpty(id))
                {
                    var user = await _userManager.FindByIdAsync(id);
                    if (user == null || !user.EmailConfirmed)
                    {
                        return BadRequest(new
                        {
                            Message = string.Format(ErrorMessageConstants.InActive, "User")
                        });
                    }
                    string code = await _userManager.GeneratePasswordResetTokenAsync(user);
                    var callbackUrl = Url.Action("ResetPassword", "Account", new { email = user.Email, code }, protocol: Request.Scheme);
                    var emailModel = new EmailRequest(
                       user.Email,    // To
                       EmailConstants.PasswordResetSubject,         // Subject
                       string.Format(EmailConstants.PasswordResetBody, $"{user.FirstName} {user.LastName}", callbackUrl), // Message
                       true                            // IsBodyHTML
                   );
                    await _emailSender.SendEmailAsync(emailModel);
                    await AddLogAsync(LogActions.SendInvite.GetDescription(), user.UserName, LogsActionSrc.UserManagement.ToString());
                    return Ok(new
                    {
                        Message = SuccessMessageConstants.ResetPasswordLink
                    });
                }
                else
                {
                    return BadRequest(new
                    {
                        Message = string.Format(ErrorMessageConstants.NotValid, "Model State")
                    });
                }
            }
            catch (Exception ex)
            {
                LogException(ex);
                return BadRequest(new
                {
                    Message = ErrorMessageConstants.Error
                });
            }
        }

        public async Task<IActionResult> BulkImportAsync()
        {
            try
            {
                IEnumerable<ApplicationRole> rolesList = _rolesRepo.GetAll().ToList();
                int validRecords = 0, invalidRecord = 0, deletedRecord = 0;
                IFormFile File = Request.Form.Files[0];
                int flag = int.Parse(Request.Form["flag"]);
                EmailRequest emailRequest = new EmailRequest();
                CsvFileDescription csvFileDescription = new CsvFileDescription
                {
                    SeparatorChar = ',',
                    FirstLineHasColumnNames = true
                };
                CsvContext csvContext = new CsvContext();
                JsonResult jsonResult = null;
                List<InvitationViewModel> inviteList = new List<InvitationViewModel>();
                var mailSettings = _mailSettings.GetAll().FirstOrDefault();
                using var reader = new StreamReader(File.OpenReadStream());
                IEnumerable<UserViewModel> list = csvContext.Read<UserViewModel>(reader, csvFileDescription);
                list = await CheckforErrors(list, rolesList);
                if (list != null)
                {
                    if (list.Count() > 0)
                    {
                        if (list.Count() <= 500)
                        {
                            if (flag == 1)
                            {
                                foreach (var user in list)
                                {
                                    if (string.IsNullOrEmpty(user.ErrorStatus))
                                        validRecords++;
                                    else if (user.ErrorStatus.Equals("Deleted"))
                                        deletedRecord++;
                                    else
                                        invalidRecord++;
                                }
                                jsonResult = Json(list.OrderBy(x => x.ErrorStatus));
                                return Ok(new
                                {
                                    Message = "Success",
                                    data = jsonResult.Value,
                                    validUsers = validRecords,
                                    invaliduser = invalidRecord,
                                    deletedUser = deletedRecord
                                });
                            }
                            else
                            {
                                int i = 0;
                                foreach (var user in list)
                                {
                                    if (string.IsNullOrEmpty(user.ErrorStatus))
                                    {
                                        i++;
                                        var row = _mapper.Map<ApplicationUser>(user);
                                        row.RoleId = rolesList.Where(x => x.Name.ToLower().Equals(user.UserRole)).Select(x => x.Id).FirstOrDefault();
                                        row.InviteTime = DateTime.Now;
                                        var result = await _userManager.CreateAsync(row);
                                        await AddLogAsync(LogActions.Add.GetDescription(), row.Email, LogsActionSrc.UserManagement.ToString());
                                        if (result.Succeeded)
                                        {
                                            var code = await _userManager.GeneratePasswordResetTokenAsync(row);
                                            inviteList.Add(new InvitationViewModel
                                            {
                                                User = row,
                                                Email = user.Email,
                                                EmailRequest = new EmailRequest(),
                                                CallBackUrl = Url.Action("SetPassword", "Account", new { user.Email, code }, protocol: Request.Scheme),
                                            });
                                        }
                                    }
                                    else if (user.ErrorStatus.Equals("Deleted"))
                                    {
                                        i++;
                                        var row = _mapper.Map<ApplicationUser>(user);
                                        var appUser = await _userManager.FindByEmailAsync(row.Email);
                                        appUser.DeletedAt = null;
                                        var result = await _userManager.UpdateAsync(appUser);
                                        await AddLogAsync(LogActions.ReActivate.GetDescription(), appUser.Email, LogsActionSrc.UserManagement.ToString());
                                    }
                                }
                                if (inviteList.Count > 0)
                                {
                                    Parallel.Invoke(() => SendEmails(inviteList, mailSettings));
                                }
                                if (i == 0)
                                    return BadRequest(new { Message = ErrorMessageConstants.AllCsvRecordsInvalid });
                                else
                                {
                                    await AddLogAsync(LogActions.Import.GetDescription(), "Users", LogsActionSrc.UserManagement.ToString());
                                    return Ok(new { Message = "Submitted", flag = i < list.ToArray().Length });
                                }
                            }
                        }
                        else
                        {
                            return BadRequest(new
                            {
                                Message = ErrorMessageConstants.MoreThanFiftyRecords
                            });
                        }
                    }
                    else
                    {
                        return BadRequest(new
                        {
                            Message = ErrorMessageConstants.EmptyCsv
                        });
                    }
                }
                else
                {
                    return BadRequest(new
                    {
                        Message = ValidationErrorConstants.InvalidCsvError
                    });
                }
            }
            catch (Exception ex)
            {
                LogException(ex);
                return BadRequest(new
                {
                    Message = ValidationErrorConstants.InvalidCsvError
                });
            }
        }

        [NonAction]
        public Task<List<UserViewModel>> CheckforErrors(IEnumerable<UserViewModel> list, IEnumerable<ApplicationRole> rolesList)
        {
            try
            {
                var usersList = _userManager.Users.Select(x => new
                {
                    x.Email,
                    x.DeletedAt,
                    x.AxCode
                }).ToList();
                List<UserViewModel> listToRet = new List<UserViewModel>();
                var emailList = list.Select(x => x.Email?.ToLower().Trim()).ToList();
                var wrongRole = list.Where(x => !string.IsNullOrEmpty(x.UserRole) && !rolesList.Any(y => y.Name == x.UserRole)).Select(x => x.Email?.ToLower()).ToList();
                var existingAxCode = usersList.Where(x => x.DeletedAt == null).Select(x => x.AxCode).ToList();
                var existingEmail = usersList.Where(x => emailList.Contains(x.Email?.ToLower().Trim()) && x.DeletedAt == null).Select(x => x.Email?.ToLower().Trim()).ToList();
                var deletedEmail = usersList.Where(x => emailList.Contains(x.Email?.ToLower().Trim()) && x.DeletedAt != null).Select(x => x.Email?.ToLower().Trim()).ToList();
                var duplicate = list.GroupBy(x => x.Email).Where(x => x.Count() > 1).SelectMany(x => x).Select(x => x.Email?.ToLower().Trim()).ToList();
                var duplicateAx = list.GroupBy(x => x.AxCode).Where(x => x.Count() > 1).SelectMany(x => x).Select(x => x.AxCode).ToList();
                list = list.Select(u => new UserViewModel()
                {
                    AxCode = u.AxCode,
                    Email = u.Email.CheckString().Trim().ToLower(),
                    FirstName = u.FirstName.CheckString().Trim(),
                    LastName = u.LastName?.CheckString().Trim()??null,
                    PhoneNumber = $"+{u.PhoneNumber.CheckString().Trim()}",
                    City = u.City.CheckString().Trim(),
                    Province = u.Province.CheckString().Trim(),
                    Address1 = u.Address1.CheckString().Trim(),
                    Address2 = u.Address2?.CheckString().Trim()??null,
                    UserRole = u.UserRole.CheckString().Trim()
                });
                listToRet = list.ToList();
                foreach (var user in listToRet)
                {
                    List<string> Errors = new List<string>();
                    user.PhoneNumber = user.PhoneNumber == "+" ? "" : user.PhoneNumber;
                    if (TryValidateModel(user))
                    {
                        user.PhoneNumber = user.PhoneNumber.Contains('+') ? user.PhoneNumber : $"+{user.PhoneNumber}";
                        user.ErrorStatus = _validationHelper.GetErrorStatus(existingEmail, deletedEmail, duplicate, existingAxCode, duplicateAx, user.Email, user.PhoneNumber, user.AxCode, wrongRole, user.UserRole);
                    }
                    else
                    {
                        user.PhoneNumber = user.PhoneNumber.Contains('+') ? user.PhoneNumber : $"+{user.PhoneNumber}";
                        var customErr = _validationHelper.GetErrorStatus(existingEmail, deletedEmail, duplicate, existingAxCode, duplicateAx, user.Email, user.PhoneNumber, user.AxCode, wrongRole, user.UserRole);
                        foreach (var err in ModelState.Values)
                            Errors.Add(err.Errors.FirstOrDefault().ErrorMessage);
                        user.ErrorStatus = string.IsNullOrEmpty(customErr) ? String.Join(",", Errors) : $"{String.Join(",", Errors)},{customErr}";
                    }
                    ModelState.Clear();
                }
                return Task.FromResult(listToRet);
            }
            catch (Exception ex)
            {
                LogException(ex);
                return null;
            }
        }
        public JsonResult CheckDupEmail(string email, string? Id = null)
        {
            var user = _userManager.Users.FirstOrDefault(x => x.Email.Trim().ToLower().Equals(email.Trim().ToLower()));
            if (string.IsNullOrEmpty(Id) && user != null)
            {
                return Json(false);
            }
            else if (!string.IsNullOrEmpty(Id) && user != null)
            {
             
                if (user.Id.Equals(Id))
                {
                    return Json(true);
                }
                return Json(false);
            }
            return Json(true);
        }
        public IActionResult CheckDupAxCode(string axCode, string Id)
        {
            var user = _userManager.Users.FirstOrDefault(x => x.AxCode.Equals(axCode));
            if (string.IsNullOrEmpty(Id) && user != null)
            {
                return Json("The AxCode already exist.");
            }
            else if (!string.IsNullOrEmpty(Id) && user != null)
            {
                Guid guidId = new Guid(Id)
;
                if (user.Id.Equals(guidId))
                {
                    return Json(true);
                }
                return Json("The AxCode already exist.");
            }
            return Json(true);
        }

        #region Helpers

        [NonAction]
        public string GetRoleId(Roles role)
        {
            return role switch
            {
                Roles.Admin => AppConstants.Admin,
                Roles.SalesManager => AppConstants.SalesManager,
                Roles.SalesPerson => AppConstants.SalePerson,
                Roles.MarketingManager => AppConstants.MarketingManager,
                _ => string.Empty,
            };
        }
        public async Task SendEmails(List<InvitationViewModel> list, EmailSettings mailSettings)
        {
            try
            {
                var i = 0;
                foreach (var item in list)
                {
                    var callbackUrl = item.CallBackUrl;
                    item.EmailRequest.Body = string.Format(EmailConstants.EmailBodyHtml,$"{item.User.FirstName} {item.User.LastName}",callbackUrl);
                    //item.EmailRequest.Body = EmailConstants.InvitationBody + " <a href=\"" + callbackUrl + "\">here</a>";
                    item.EmailRequest.ToEmail = item.Email;
                    item.EmailRequest.Subject = EmailConstants.InvitationSubject;
                    item.EmailRequest.IsBodyHtml = true;
                    using var smtpclient = new SmtpClient();
                    var credential = new NetworkCredential
                    {
                        UserName = mailSettings.SmtpEmailAddress,
                        Password = mailSettings.SmtpPassword
                    };

                    smtpclient.Port = mailSettings.SmtpPort;
                    smtpclient.EnableSsl = mailSettings.EnableSSL;
                    smtpclient.UseDefaultCredentials = false;
                    smtpclient.Credentials = credential;
                    smtpclient.Host = mailSettings.SmtpHost;
                    smtpclient.DeliveryMethod = SmtpDeliveryMethod.Network;

                    MailMessage mailMessage = new MailMessage
                    {
                        From = new MailAddress(mailSettings.SmtpEmailAddress),
                        BodyEncoding = Encoding.UTF8
                    };
                    mailMessage.To.Add(item.EmailRequest.ToEmail);
                    mailMessage.Body = item.EmailRequest.Body;
                    mailMessage.Subject = item.EmailRequest.Subject;
                    mailMessage.IsBodyHtml = item.EmailRequest.IsBodyHtml;

                    await smtpclient.SendMailAsync(mailMessage);
                }
            }
            catch(Exception ex)
            {
                Debug.WriteLine(ex);
            }
        }

        #endregion Helpers
    }
}