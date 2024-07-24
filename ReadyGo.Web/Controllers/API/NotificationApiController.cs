using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using ReadyGo.Domain.Constants;
using ReadyGo.Domain.Entities;
using ReadyGo.Domain.Entities.ApiModels;
using ReadyGo.Domain.Entities.Identity;
using ReadyGo.Domain.Enum;
using ReadyGo.Persistence.Seeds;
using ReadyGo.Service.Repositories.Interfaces;
using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using ReadyGo.Service.Interfaces;
using System.Collections.Generic;
using Microsoft.AspNetCore.Authentication.JwtBearer;

namespace ReadyGo.Web.Controllers.API
{
    [ApiController]
    [ApiVersion("1.0")]
    [ApiExplorerSettings(GroupName = "mobile")]
    [Route("api/v{version:apiVersion}/Notification/")]
    public class NotificationApiController : BaseApiController
    {
        private readonly IGenericRepository<UserNotification> _notificationRepo;
        private readonly INotificationService _notificationService;
        private readonly UserManager<ApplicationUser> _userManager;

        public NotificationApiController(IGenericRepository<UserNotification> notificationRepo,
            INotificationService notificationService,
            UserManager<ApplicationUser> userManager)
        {
            _notificationRepo = notificationRepo;
            _notificationService = notificationService;
            _userManager = userManager;
        }

        /// <summary>
        ///   Get notifications.
        /// </summary>
        /// <param name="id"></param>
        /// <returns>List of notificaitons</returns>
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [HttpGet]
        [Route("UserNotifications")]
        public IActionResult UserNotifications(DateTime? fromDate = null)
        {
            try
            {
                List<NotificationApiViewModel> viewModelList = new List<NotificationApiViewModel>();
                var email = DecodeJwt();
                var curUser = _userManager.Users.
                    Include(x => x.Notifications.Where(x => x.DeletedAt == null)).ThenInclude(x => x.Notification)
                    .FirstOrDefault(x => x.Email.Equals(email));

                if (!curUser.IsActive)
                {
                    return Forbid();
                }

                var notificationQuery = curUser.Notifications.AsEnumerable();
                if (fromDate != null)
                {
                    notificationQuery = notificationQuery.Where(x => x.Notification.CreatedAt >= fromDate && x.Notification.DeletedAt == null);
                }
                else
                {
                    notificationQuery = notificationQuery.Where(x => x.Notification.CreatedAt > DateTime.Now.AddDays(-7) && x.Notification.DeletedAt == null);
                }
                notificationQuery = notificationQuery?.OrderByDescending(x => x.Notification.CreatedAt)
                    .OrderByDescending(x => x.Notification.CreatedAt).ToList();
                foreach (var item in notificationQuery)
                {
                    viewModelList.Add(new NotificationApiViewModel
                    {
                        Id = item.NotificationId,
                        Content = item.Notification.Content,
                        CreatedAt = item.Notification.CreatedAt
                    });
                }
                var responseData = new
                {
                    Notifications = viewModelList
                };

                return Ok(new ApiResponseModel(responseData));
            }
            catch (Exception ex)
            {
                return BadRequest(new ApiResponseModel(ApiStatus.Error, ApiErrors.DefaultError.GetDescription(), ApiErrors.DefaultError));
            }
        }
    }

}
