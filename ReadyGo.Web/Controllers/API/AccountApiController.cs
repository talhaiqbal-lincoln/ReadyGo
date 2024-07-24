using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using ReadyGo.Domain.Constants;
using ReadyGo.Domain.Entities.ApiModels;
using ReadyGo.Domain.Entities.Identity;
using ReadyGo.Domain.Entities.ViewModels;
using ReadyGo.Domain.Enum;
using ReadyGo.Infrastructure.ViewModel;
using ReadyGo.Persistence.Seeds;
using ReadyGo.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace ReadyGo.Web.Controllers.API
{
    [ApiController]
    [ApiVersion("1.0")]
    [ApiExplorerSettings(GroupName = "mobile")]
    [Route("api/v{version:apiVersion}/Account/")]
    public class AccountApiController : BaseApiController
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IConfiguration _configuration;
        private readonly IMapper _mapper;
        private readonly IEmailService _sender;

        public AccountApiController(UserManager<ApplicationUser> userManager, IConfiguration configuration,
            IEmailService sender, IMapper mapper)
        {
            _userManager = userManager;
            _configuration = configuration;
            _sender = sender;
            _mapper = mapper;
        }

        /// <summary>
        /// Method for User Login
        /// </summary>
        /// <param name="model"></param>
        /// <returns>Token if the user is authenticated</returns>
        /// <response code="200">Returns the JWT token</response>
        /// <response code="500">If user enters wrong Credentials </response>
        [AllowAnonymous]
        [HttpPost]
        [Route("Login")]
        public async Task<IActionResult> Login([FromBody] LoginViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(new ApiResponseModel(ApiStatus.Error, ApiErrors.ModelState.GetDescription(), ApiErrors.ModelState));
            }
            try
            {
                var user = _userManager.Users.Include(x=>x.ProfileImage)
                    .Include(x => x.Role).FirstOrDefault(x => x.Email.Equals(model.Email.Trim().ToLower()));
                if (user != null)
                {
                    var result = await _userManager.CheckPasswordAsync(user, model.Password);
                    if (result)
                    {
                        if (user.IsActive == false || user.DeletedAt != null)
                        {
                            return BadRequest(new ApiResponseModel(ApiStatus.Error,ApiErrors.InActive.GetDescription(),ApiErrors.InActive));
                        }
                        if (user.Role.Name != Roles.SalesPerson.GetDescription())
                        {
                            return BadRequest(new ApiResponseModel(ApiStatus.Error, ApiErrors.InValidRole.GetDescription(), ApiErrors.InValidRole));
                        }
                        var userResponse = _mapper.Map<UserApiViewModel>(user);
                        var authClaims = new List<Claim>
                        {
                            new Claim(ClaimTypes.Name, user.Email),
                            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                        };

                        var authSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:Secret"]));

                        var token = new JwtSecurityToken(
                            issuer: _configuration["JWT:ValidIssuer"],
                            audience: _configuration["JWT:ValidAudience"],
                            expires: DateTime.Now.AddHours(24),
                            claims: authClaims,
                            signingCredentials: new SigningCredentials(authSigningKey, SecurityAlgorithms.HmacSha256)
                            );

                        var responseData = new
                        {
                            token = new JwtSecurityTokenHandler().WriteToken(token),
                            expiration = token.ValidTo,
                            userResponse.Email,
                            userResponse.UserName,
                            userResponse.Image
                        };
                        return Ok(new ApiResponseModel(responseData));
                    }
                    return BadRequest(new ApiResponseModel(ApiStatus.Error, ApiErrors.WrongEmailPass.GetDescription(), ApiErrors.WrongEmailPass));
                }
                else
                {

                    return BadRequest(new ApiResponseModel(ApiStatus.Error, ApiErrors.WrongEmailPass.GetDescription(), ApiErrors.WrongEmailPass));
                }
            }
            catch (Exception ex)
            {
                return BadRequest(new ApiResponseModel(ApiStatus.Error, ApiErrors.DefaultError.GetDescription(), ApiErrors.DefaultError));
            }
        }

        /// <summary>
        /// Method for Forget Password
        /// </summary>
        /// <param name="model"></param>
        /// <remarks>
        /// Sample request:
        ///
        ///     POST /Todo
        ///     {
        ///        "Email : "string@string.com",
        ///     }
        ///
        /// </remarks>
        /// <returns> Message based on valid user</returns>
        /// <response code="200">Returns verification code</response>
        /// <response code="500">If the user not found </response>
        [AllowAnonymous]
        [HttpPost]
        [Route("ForgetPassword")]
        public async Task<ActionResult> ForgotPassword(ForgotPasswordViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(new ApiResponseModel(ApiStatus.Error, ApiErrors.ModelState.GetDescription(), ApiErrors.ModelState));
            }
            try
            {
                var user = await _userManager.FindByEmailAsync(model.Email);
                if (user == null || !(await _userManager.IsEmailConfirmedAsync(user)))
                {
                    // Don't reveal that the user does not exist or is not confirmed
                    return BadRequest(new ApiResponseModel(ApiStatus.Error, "User " + ApiErrors.NotFound.GetDescription(), ApiErrors.NotFound));
                }
                if (!user.IsActive || user.DeletedAt != null)
                {
                    return BadRequest(new ApiResponseModel(ApiStatus.Error,ApiErrors.InActive.GetDescription(), ApiErrors.InActive));
                }

                // For more information on how to enable account confirmation and password reset please visit https://go.microsoft.com/fwlink/?LinkID=320771
                // Send an email with this link
                var rnd = new Random();
                var sixDigCode = rnd.Next(100000, 999999);
                string code = await _userManager.GeneratePasswordResetTokenAsync(user);
                var emailModel = new EmailRequest(
                   model.Email,
                   EmailConstants.PasswordResetSubject,
                   "6 digit verification code: " + sixDigCode,
                   true
               );
                await _sender.SendEmailAsync(emailModel);

                var responseData = new
                {
                    code,
                    sixDigitCode = sixDigCode
                };
                return Ok(new ApiResponseModel(responseData));
            }
            catch (Exception ex)
            {
                return BadRequest(new ApiResponseModel(ApiStatus.Error, ApiErrors.DefaultError.GetDescription(), ApiErrors.DefaultError));
            }
        }

        /// <summary>
        /// Method for Reset Password
        /// </summary>
        /// <param name="model"></param>
        /// <remarks>
        /// Sample request:
        ///
        ///     POST /Todo
        ///     {
        ///        "Email : "string@string.com",
        ///        "Password":"string",
        ///        "ConfirmPassword":"string",
        ///        "Code":"string"
        ///     }
        ///
        /// </remarks>
        /// <returns> Message based on password reset</returns>
        /// <response code="200">Returns success if password reset</response>
        /// <response code="500">If error occur in reseting password </response>
        [AllowAnonymous]
        [HttpPost]
        [Route("ResetPassword")]
        public async Task<ActionResult> ResetPassword(ResetPasswordViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(new ApiResponseModel(ApiStatus.Error, ApiErrors.ModelState.GetDescription(), ApiErrors.ModelState));
            }
            try
            {
                var user = await _userManager.FindByEmailAsync(model.Email.ToLower());
                if (user != null)
                {
                    var result = await _userManager.ResetPasswordAsync(user, model.Code, model.Password);
                    if (result.Succeeded)
                    {
                 
                        var responseData = new
                        {
                            Message = SuccessMessageConstants.PasswordReset
                        };
                        return Ok(new ApiResponseModel(responseData));
                    }
                    else
                    {
                        return BadRequest(new ApiResponseModel(ApiStatus.Error,String.Join(",", result.Errors), ApiErrors.DefaultError));
                    }
                }
                else
                {
                    return BadRequest(new ApiResponseModel(ApiStatus.Error, "User " + ApiErrors.NotFound.GetDescription(), ApiErrors.NotFound));
                }
            }
            catch (Exception ex)
            {
                return BadRequest(new ApiResponseModel(ApiStatus.Error, ApiErrors.DefaultError.GetDescription(), ApiErrors.DefaultError));
            }
        }

        [Authorize(AuthenticationSchemes = JwtAuthenticationConstants.AuthenticationScheme)]
        [HttpGet]
        [Route("Profile")]
        public ActionResult GetProfile()
        {
            try
            {
                var email = DecodeJwt();
                var user = _userManager.Users.Include(x => x.ProfileImage).First(x => x.Email.Equals(email));
                var userResponse = _mapper.Map<UserApiViewModel>(user);

                var responseData = new
                {
                    Message = SuccessMessageConstants.DefaultSuccess,
                    userResponse
                };
                return Ok(new ApiResponseModel(responseData));
            }
            catch (Exception ex)
            {            
                return BadRequest(new ApiResponseModel(ApiStatus.Error, ApiErrors.DefaultError.GetDescription(), ApiErrors.DefaultError));
            }
        }

        /// <summary>
        /// Method for Change Password
        /// </summary>
        /// <param name="model"></param>
        /// <remarks>
        /// Sample request:
        ///
        ///     POST /Todo
        ///     {
        ///        "OldPassword":"string",
        ///        "NewPassword":"string",
        ///        "ConfirmPassword":"string"
        ///     }
        ///
        /// </remarks>
        /// <returns> Message based on password updation</returns>
        /// <response code="200">Returns success if password updation</response>
        /// <response code="500">If error occur in updating password </response>
        [Authorize(AuthenticationSchemes = JwtAuthenticationConstants.AuthenticationScheme)]
        [HttpPost]
        [Route("ChangePassword")]
        public async Task<IActionResult> ChangePasswordAsync(ChangePasswordViewModel model)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(new ApiResponseModel(ApiStatus.Error, ApiErrors.ModelState.GetDescription(), ApiErrors.ModelState));
                }
                else
                {
                    var email = DecodeJwt();
                    var user = await _userManager.FindByEmailAsync(email);
                    PasswordVerificationResult passresult = _userManager.PasswordHasher.VerifyHashedPassword(user, user.PasswordHash, model.OldPassword);
                    if (passresult.ToString() == "Success")
                    {
                        var result = await _userManager.ChangePasswordAsync(user, model.OldPassword, model.NewPassword);
                        if (result.Succeeded)
                        {
                            var responseData = new
                            {
                                Message = SuccessMessageConstants.PasswordReset
                            };
                            return Ok(new ApiResponseModel(responseData));
                        }
                        else
                        {
                            return BadRequest(new ApiResponseModel(ApiStatus.Error,ApiErrors.DefaultError.GetDescription(), ApiErrors.DefaultError));
                        }
                    }
                    else
                    {
                        return BadRequest(new ApiResponseModel(ApiStatus.Error,ApiErrors.IncorrectOldPassword.GetDescription(), ApiErrors.IncorrectOldPassword));
                    }
                }
            }
            catch (Exception)
            {
                return BadRequest(new ApiResponseModel(ApiStatus.Error, ApiErrors.DefaultError.GetDescription(), ApiErrors.DefaultError));
            }
          
        }
    }
}