using AutoMapper;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using ReadyGo.Domain.Constants;
using ReadyGo.Domain.Entities.Identity;
using ReadyGo.Domain.Entities.ViewModels;
using ReadyGo.Domain.Enum;
using ReadyGo.Infrastructure.Filters;
using ReadyGo.Infrastructure.ViewModel;
using ReadyGo.Persistence.Seeds;
using ReadyGo.Service.Interfaces;
using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ReadyGo.Service.Repositories.Interfaces;
using ReadyGo.Domain.Entities;
using Microsoft.Extensions.Configuration;

namespace ReadyGo.Web.Controllers
{
    public class AccountController : BaseController
    {
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly RoleManager<ApplicationRole> _roleManager;
        private readonly IMapper _mapper;
        private readonly IGenericRepository<Configuration> _configurations;
        private readonly IConfiguration _config;

        public AccountController(SignInManager<ApplicationUser> signInManager,
            RoleManager<ApplicationRole> roleManager, IMapper mapper,
            IGenericRepository<Configuration> configurations,
            IConfiguration config)
        {
            _config = config;
            _signInManager = signInManager;
            _roleManager = roleManager;
            _mapper = mapper;
            _configurations = configurations;
        }

        /// <summary>
        /// GET: /Account/Login
        /// </summary>
        /// <param name="returnUrl"></param>
        /// <returns>Login View</returns>
        [AllowAnonymous]
        [LoggedInUserFilter]
        public async Task<ActionResult> Login(string returnUrl)
        {
            ViewBag.ReturnUrl = returnUrl;
            // Clear the existing external cookie to ensure a clean login process
            await HttpContext.SignOutAsync(IdentityConstants.ExternalScheme);
            return View();
        }

        /// <summary>
        /// Handle login request
        /// </summary>
        /// <param name="model"></param>
        /// <param name="returnUrl"></param>
        /// <returns>Redirect to home page if user is valid</returns>
        /// <returns>Display error message if user is invalid</returns>
        [HttpPost]
        [AllowAnonymous]
        [ModelValidationFilter]
        [LoggedInUserFilter]
        public async Task<ActionResult> Login(LoginViewModel model, string returnUrl)
        {
            try
            {
                // This doesn't count login failures towards account lockout
                // To enable password failures to trigger account lockout, change to shouldLockout: true
                var user = _userManager.Users.Include(a => a.Role).FirstOrDefault(u => u.Email.Equals(model.Email.ToLower()));
                if (user != null)
                {
                    var checkpassword = await _userManager.CheckPasswordAsync(user, model.Password);
                    if (checkpassword)
                    {
                        if (user.Role.NormalizedName == EnumExtension.GetDescription(Roles.SalesPerson))
                        {
                            ViewBag.Message = ErrorMessageConstants.SalesPersonLogin;
                            return View();
                        }
                        if (user.IsActive == false || user.DeletedAt != null)
                        {
                            ViewBag.Message = ErrorMessageConstants.InactiveLogin;
                            return View();
                        }
                        var result = await _signInManager.PasswordSignInAsync(user.UserName, model.Password, model.RememberMe, lockoutOnFailure: false);
                        if (result.IsNotAllowed)
                        {
                            ViewBag.Message = ErrorMessageConstants.EmailUnconfirmed;
                            return View();
                        }
                        else if (result.Succeeded)
                        {
                            if (string.IsNullOrEmpty(returnUrl) || returnUrl == "/")
                            {
                                return RedirectToAction("Index", "Home");
                            }
                            return LocalRedirect(returnUrl);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                LogException(ex);
                return LocalRedirect(returnUrl);
            }

            ViewBag.Message = ErrorMessageConstants.InvalidEmailOrPassword;
            return View();
        }

        [HttpGet]
        public async Task<ActionResult> LogOffAsync()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Login", "Account");
        }

        /// <summary>
        /// GET: /Account/SetPassword
        /// </summary>
        /// <param name="email"></param>
        /// <param name="code"></param>
        /// <returns>SetPassword View</returns>
        [AllowAnonymous]
        [LoggedInUserFilter]
        public async Task<ActionResult> SetPassword(string email, string code)
        {
            SetPasswordViewModel model = new SetPasswordViewModel
            {
                Email = email,
                Code = code
            };
            try
            {
                if (!string.IsNullOrEmpty(email) || !string.IsNullOrEmpty(code))
                {
                    var user = await _userManager.FindByEmailAsync(email.ToLower());
                    if (user != null)
                    {
                        model = _mapper.Map<SetPasswordViewModel>(user);

                        return View(model);
                    }
                    return RedirectToAction("Login");
                }
                return RedirectToAction("Login");
            }
            catch (Exception ex)
            {
                LogException(ex);
                return code == null ? View("Error") : View(model);
            }
        }

        /// <summary>
        /// POST: /Account/SetPassword
        /// </summary>
        /// <param name="model"></param>
        /// <returns>Redirect to home page if user is valid</returns>
        /// <returns>Display error message if user is invalid</returns>
        [HttpPost]
        [AllowAnonymous]
        [ModelValidationFilter]
        [LoggedInUserFilter]
        public async Task<ActionResult> SetPassword(SetPasswordViewModel model)
        {
            try
            {
                var user = _userManager.Users.Where(x => x.Email == model.Email.ToLower() && !x.DeletedAt.HasValue && x.IsActive).FirstOrDefault();
                if (user != null)
                {
                    var result = await _userManager.ResetPasswordAsync(user, model.Code, model.Password);
                    if (result.Succeeded)
                    {
                        _mapper.Map<SetPasswordViewModel, IdentityUser>(model, user);
                        user.EmailConfirmed = true;
                        var update = await _userManager.UpdateAsync(user);
                        if (update.Succeeded)
                        {
                            if (user.RoleId.Equals(AppConstants.SalePerson))
                            {
                                return RedirectToAction("Login");
                            }
                            await _signInManager.PasswordSignInAsync(user, model.Password, false, false);
                            return RedirectToAction("Index", "Home");
                        }
                        else
                        {
                            ViewBag.Message = ErrorMessageConstants.SetPasswordError;
                            return View(model);
                        }
                    }
                    else
                    {
                        foreach (var error in result.Errors)
                        {
                            ModelState.AddModelError("", error.Description);
                        }
                        return View(model);
                    }
                }
                ViewBag.Message = ErrorMessageConstants.DeletedRegistration;
                return View(model);
            }
            catch (Exception ex)
            {
                LogException(ex);
                return RedirectToAction("Login");
            }
        }

        /// <summary>
        /// GET: /Account/ForgotPassword
        /// </summary>
        /// <returns>Forget Password View</returns>
        [AllowAnonymous]
        [LoggedInUserFilter]
        public ActionResult ForgotPassword()
        {
            return View();
        }

        //
        // POST: /Account/ForgotPassword
        /// <summary>
        /// POST: /Account/ForgotPassword Handle post request and send reset password email to user
        /// </summary>
        /// <param name="model"></param>
        /// <returns>Reset password link to user</returns>
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        [LoggedInUserFilter]
        [ModelValidationFilter]
        public async Task<ActionResult> ForgotPassword(ForgotPasswordViewModel model)
        {

            var user = await _userManager.FindByEmailAsync(model.Email);
            if (user == null || !user.EmailConfirmed)
            {
                // Don't reveal that the user does not exist or is not confirmed
                ModelState.AddModelError("Email", ValidationErrorConstants.NotValidOrInactive);
                return View(model);
            }

            // For more information on how to enable account confirmation and password reset please visit https://go.microsoft.com/fwlink/?LinkID=320771
            // Send an email with this link
            string code = await _userManager.GeneratePasswordResetTokenAsync(user);
            var callbackUrl = Url.Action("ResetPassword", "Account", new { email = user.Email, code }, protocol: Request.Scheme);
            var emailModel = new EmailRequest(
               model.Email,    // To
               EmailConstants.PasswordResetSubject,         // Subject
               string.Format(EmailConstants.PasswordResetBody, $"{user.FirstName} {user.LastName}", callbackUrl), // Message
               true                            // IsBodyHTML
           );
            await _emailSender.SendEmailAsync(emailModel);
            return RedirectToAction("ForgotPasswordConfirmation", "Account");
        }

        /// <summary>
        /// GET: /Account/ForgotPasswordConfirmation
        /// </summary>
        /// <returns>Confirmation view</returns>
        [AllowAnonymous]
        [LoggedInUserFilter]
        public ActionResult ForgotPasswordConfirmation()
        {
            return View();
        }

        /// <summary>
        /// GET: /Account/ResetPassword
        /// </summary>
        /// <param name="email"></param>
        /// <param name="code"></param>
        /// <returns>Password reset view where user will enter new password</returns>
        [AllowAnonymous]
        [LoggedInUserFilter]
        public ActionResult ResetPassword(string email, string code)
        {
            ResetPasswordViewModel model = new ResetPasswordViewModel
            {
                Email = email,
                Code = code
            };
            return string.IsNullOrEmpty(code) ? View("Error") : View(model);
        }

        /// <summary>
        /// POST: /Account/ResetPassword Handle reset password request
        /// </summary>
        /// <param name="model"></param>
        /// <returns>Reset password confirmation</returns>
        [HttpPost]
        [AllowAnonymous]
        [ModelValidationFilter]
        [LoggedInUserFilter]
        public async Task<ActionResult> ResetPassword(ResetPasswordViewModel model)
        {
            var user = await _userManager.FindByEmailAsync(model.Email.ToLower());
            if (user != null)
            {
                var result = await _userManager.ResetPasswordAsync(user, model.Code, model.Password);
                if (result.Succeeded)
                {
                    return RedirectToAction("ResetPasswordConfirmation", "Account");
                }
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
            }
            else
            {
                // Don't reveal that the user does not exist
                return RedirectToAction("ResetPasswordConfirmation", "Account");
            }
            // AddErrors(result);
            return View(model);
        }

        /// <summary>
        /// GET: /Account/ResetPasswordConfirmation
        /// </summary>
        /// <param name="model"></param>
        /// <returns>Reset password confirmation view</returns>
        [AllowAnonymous]
        [LoggedInUserFilter]
        public ActionResult ResetPasswordConfirmation()
        {
            return View();
        }

        /// <summary>
        /// GET: /Account/ManageProfile
        /// </summary>
        /// <returns>Manage user profile view</returns>
        [Authorize]
        public IActionResult ManageProfile()
        {
            var user = _userManager.Users
                .Include(x => x.NotificationSettings)
                .Include(x => x.ProfileImage)
                .Include(x => x.Role)
                .First(x => x.Id.Equals(User.Claims.First().Value));
            var model = _mapper.Map<UserViewModel>(user);
            if (user.Role.Name.Equals(Roles.Admin.GetDescription()))
            {
                foreach (var setting in user.NotificationSettings)
                {
                    if (setting.NotificationType == NotficationEnums.SalesPerson)
                        model.SpNotification = true;
                    if (setting.NotificationType == NotficationEnums.SalesManager)
                        model.SmNotification = true;
                    if (setting.NotificationType == NotficationEnums.MarketingManager)
                        model.MmNotification = true;
                }
            }
            else
            {
                foreach (var setting in user.NotificationSettings)
                {
                    if (setting.NotificationType == NotficationEnums.DiscountedOrder)
                        model.SmNotification = true;
                    if (setting.NotificationType == NotficationEnums.SalesPersonRoute)
                        model.SpNotification = true;
                    if (setting.NotificationType == NotficationEnums.CustomerAdded)
                        model.MmNotification = true;
                }
            }
            ViewData["NotificationSettings"] = _configurations.GetAll().ToList();
            return View(model);
        }

        /// <summary>
        /// POST: /Account/ManageProfile Handle requestto update profile infoe
        /// </summary>
        /// <param name="user"></param>
        /// <returns>Confirmation message</returns>
        [HttpPost]
        [ModelValidationFilter]
        public async Task<IActionResult> ManageProfileAsync(UserViewModel user)
        {
            try
            {
                var appUser = await _userManager.GetUserAsync(User);
                _mapper.Map<UserViewModel, ApplicationUser>(user, appUser);
                await _userManager.UpdateAsync(appUser);
                return Ok(new
                {
                    Message = string.Format(SuccessMessageConstants.UpdateSuccess, "Profile")
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

        [HttpPost]
        public async Task<IActionResult> UpdateImage(IFormFile file)
        {
            try
            {
                var user = _userManager.Users.Include(x => x.ProfileImage).
                    First(x => x.Id.Equals(User.Claims.First().Value));
                user = HandleImage(file, user);
                await _userManager.UpdateAsync(user);

                return Ok(new
                {
                    Message = string.Format(SuccessMessageConstants.UpdateSuccess, "Profile Image")
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
        /// GET: /Account/ChangePassword
        /// </summary>
        /// <returns>return changepassword partial view</returns>
        public IActionResult ChangePasswordFields()
        {
            return PartialView("_ChangePassword");
        }

        /// <summary>
        /// POST: /Account/ChangePasssword Handle request to change password
        /// </summary>
        /// <param name="model"></param>
        /// <returns>Confirmation message</returns>
        [HttpPost]
        [ModelValidationFilter]
        public async Task<IActionResult> ChangePasswordAsync(ChangePasswordViewModel model)
        {
            var user = await _userManager.GetUserAsync(User);
            var result = await _userManager.ChangePasswordAsync(user, model.OldPassword, model.NewPassword);
            if (result.Succeeded)
            {
                return Ok(new
                {
                    Message = string.Format(SuccessMessageConstants.UpdateSuccess, "Password")
                });
            }
            else
            {
                return BadRequest(new
                {
                    Message = string.Format(ErrorMessageConstants.NotValid, "The Old password")
                });
            }
        }

        /// <summary>
        /// POST:/Account/CheckEmail Check whether email exist in db or not
        /// </summary>
        /// <param name="email"></param>
        /// <returns>bool true is exist and false if not</returns>
        [HttpPost]
        [AllowAnonymous]
        public JsonResult CheckMail(string email)
        {
            if (_userManager.Users.Any(x => x.Email.Equals(email.ToLower().Trim())))
            {
                return Json(true);
            }

            return Json(false);
        }
        [HttpDelete]
        public async Task<IActionResult> DeleteDpAsync(string id)
        {
            try
            {
                var currUser = await _userManager.GetUserAsync(User);
                var profileImage = _imgRepo.Get(new Guid(id));
                currUser.ProfileImageId = null;
                await _userManager.UpdateAsync(currUser);
                _imgRepo.Delete(profileImage);
                return Ok(new
                {
                    Message = string.Format(SuccessMessageConstants.DeleteSuccess, "Display picture")
                });
            }
            catch (Exception ex)
            {
                return BadRequest(new
                {
                    Message = ErrorMessageConstants.Error
                });
            }
        }
        [ModelValidationFilter]
        [HttpPost]
        public async Task<IActionResult> ContactUsAsync(ContactViewModel model)
        {
            //return Ok();
            try
            {
                var email = _config.GetSection("Email").Value;
                var emailModel = new EmailRequest(
                   email,    // To
                   EmailConstants.ContactUsSubject,         // Subject
                   string.Format("Customer {0} {1} ({2}) wants to contact, \n Message: {3}", model.FirstName, model.LastName,
                   model.Email, model.Message), // Message
                   true                            // IsBodyHTML
               );
                await _emailSender.SendEmailAsync(emailModel);
                return Ok(new
                {
                    Message = EmailConstants.SendSuccess
                });
            }
            catch (Exception ex)
            {
                return BadRequest(new
                {
                    Message = EmailConstants.SendFail
                });
            }
        }
        public IActionResult ContactPage()
        {
            return View();
        }

        public IActionResult TermsPage()
        {
            return View();
        }

        #region Helpers

        private void AddErrors(IdentityResult result)
        {
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError("", error.ToString());
            }
        }
        private ActionResult RedirectToLocal(string returnUrl)
        {
            if (Url.IsLocalUrl(returnUrl))
            {
                return Redirect(returnUrl);
            }
            return RedirectToAction("Login", "Account");
        }

        #endregion Helpers
    }
}