using Microsoft.AspNetCore.Mvc;
using ReadyGo.Domain.Constants;
using ReadyGo.Domain.Entities;
using ReadyGo.Service.Interfaces;
using ReadyGo.Service.Repositories.Interfaces;
using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using ReadyGo.Domain.Entities.ViewModels;
using ReadyGo.Domain.Enum;
using System.Threading.Tasks;
using ReadyGo.Persistence.Seeds;

namespace ReadyGo.Web.Controllers
{
    public class NotificationController : BaseController
    {
        private readonly IGenericRepository<UserNotification> _userNotificationRepo;
        private readonly IGenericRepository<NotificationSettings> _notificationSettingsRepo;
        private readonly INotificationService _notificationService;
        public NotificationController(
            IGenericRepository<UserNotification> userNotificationRepo, 
            INotificationService notificationService,
            IGenericRepository<NotificationSettings> notificationSettingsRepo)
        {
            _userNotificationRepo = userNotificationRepo;
            _notificationService = notificationService;
            _notificationSettingsRepo = notificationSettingsRepo;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult ChangeReadStatus(string id)
        {
            try
            {
                Guid n_id = new Guid(id);
                var notification = _userNotificationRepo.Get(n_id);
                notification.IsRead = true;
                _userNotificationRepo.Update(notification);
                return Ok();
            }
            catch(Exception ex)
            {
                LogException(ex);
                return BadRequest(new
                {
                    Message = ErrorMessageConstants.Error
                });
            }
        }

        public IActionResult UserNotifications()
        {
            try
            {
                var draw = Request.Form["draw"].FirstOrDefault();
                var status = Request.Form["status"].FirstOrDefault();
                var start = Request.Form["start"].FirstOrDefault();
                var length = Request.Form["length"].FirstOrDefault();
                var sortColumnDirection = Request.Form["order[0][dir]"].FirstOrDefault();
                var searchValue = Request.Form["search"].FirstOrDefault().Trim();
                var flag = Request.Form["flag"].FirstOrDefault();
                int pageSize = Convert.ToInt32(length ?? "0");
                int skip = Convert.ToInt32(start ?? "0");
                int recordsTotal = 0;
                var notificationData = _userNotificationRepo.FindAll(x => x.UserId.Equals(User.Claims.First().Value)).
                    Include(x => x.Notification).ThenInclude(x => x.CreatedBy).ThenInclude(x => x.ProfileImage)
                    .ToList();

                var notifications = notificationData.OrderByDescending(x => x.Notification.CreatedAt).Select(x => new NotificationTableViewModel
                {
                    ProfileImage = x.Notification.CreatedBy.ProfileImage != null ? "data:image;base64," + Convert.ToBase64String(x.Notification.CreatedBy.ProfileImage.File) : "/resource_files/default_user.jpg",
                    CreatedBy = x.Notification.CreatedBy.FirstName + " " + x.Notification.CreatedBy.LastName,
                    Content = x.Notification.Content,
                    TimeSpan = _notificationService.GetTimeSpan(x.Notification.CreatedAt),
                    IsRead = x.IsRead,
                    RedirectUrl = x.Notification.RedirectUrl,
                    Id = x.Id
                });
                if (!string.IsNullOrEmpty(searchValue))
                {
                    notifications = notifications.Where(m => m.CreatedBy.Contains(searchValue, StringComparison.OrdinalIgnoreCase)
                                        || m.Content.Contains(searchValue, StringComparison.OrdinalIgnoreCase));
                }
                recordsTotal = notifications.Count();
                var data = notifications.Skip(skip).Take(pageSize).ToList();

                return Json(new { draw, recordsFiltered = recordsTotal, recordsTotal, data });
            }
            catch (Exception ex)
            {
                LogException(ex);
                return null;
            }
        }
        public IActionResult MarkAll()
        {
            try
            {
                var notifications = _userNotificationRepo.FindAll(x => x.UserId.Equals(User.Claims.First().Value)).ToList();
                notifications.ForEach(x => x.IsRead = true);
                _userNotificationRepo.UpdateRange(notifications);
                return Ok();
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
        public async Task<IActionResult> NotificationSettingAsync()
        {
            try
            {
                var sm_not = Request.Form["SmNotification"].ToArray();
                var sp_not = Request.Form["SpNotification"].ToArray();
                var mm_not = Request.Form["MmNotification"].ToArray();
                var SmNotification = sm_not.Count() > 0 ? Convert.ToBoolean(Convert.ToInt32(sm_not.Length > 1 ? sm_not[1].ToString() : sm_not[0].ToString())) : false;
                var SpNotification = sp_not.Count() > 0 ? Convert.ToBoolean(Convert.ToInt32(sp_not.Length > 1 ? sp_not[1].ToString() : sp_not[0].ToString())) : false;
                var MmNotification = mm_not.Count() > 0 ? Convert.ToBoolean(Convert.ToInt32(mm_not.Length > 1 ? mm_not[1].ToString() : mm_not[0].ToString())) : false;
                var curr_user = await _userManager.GetUserAsync(User);
                var user = _userManager.Users
                    .Include(x => x.Role)
                    .First(x => x.Id.Equals(User.Claims.First().Value));

                if (SmNotification)
                {
                    if (user.Role.Name == Roles.Admin.GetDescription())
                    {
                        var setting = _notificationSettingsRepo.FindBy(x => x.NotificationType == NotficationEnums.SalesManager && x.UserId == user.Id);
                        if (setting == null)
                        {
                            _notificationSettingsRepo.Insert(new NotificationSettings
                            {
                                UserId = user.Id,
                                NotificationType = NotficationEnums.SalesManager
                            });
                        }
                    }
                    else
                    {
                        var setting = _notificationSettingsRepo.FindBy(x => x.NotificationType == NotficationEnums.DiscountedOrder && x.UserId == user.Id);
                        if (setting == null)
                        {
                            _notificationSettingsRepo.Insert(new NotificationSettings
                            {
                                UserId = user.Id,
                                NotificationType = NotficationEnums.DiscountedOrder
                            });
                        }
                    }
                }
                else
                {
                    if (user.Role.Name == Roles.Admin.ToString())
                    {
                        var setting = _notificationSettingsRepo.FindBy(x => x.NotificationType == NotficationEnums.SalesManager && x.UserId == user.Id);
                        if (setting != null)
                        {
                            _notificationSettingsRepo.Delete(setting);
                        }
                    }
                    else
                    {
                        var setting = _notificationSettingsRepo.FindBy(x => x.NotificationType == NotficationEnums.DiscountedOrder && x.UserId == user.Id);
                        if (setting != null)
                        {
                            _notificationSettingsRepo.Delete(setting);
                        }
                    }
                }

                if (SpNotification)
                {
                    if (user.Role.Name == Roles.Admin.GetDescription())
                    {
                        var setting = _notificationSettingsRepo.FindBy(x => x.NotificationType == NotficationEnums.SalesPerson && x.UserId == user.Id);
                        if (setting == null)
                        {
                            _notificationSettingsRepo.Insert(new NotificationSettings
                            {
                                UserId = user.Id,
                                NotificationType = NotficationEnums.SalesPerson
                            });
                        }
                    }
                    else
                    {
                        var setting = _notificationSettingsRepo.FindBy(x => x.NotificationType == NotficationEnums.SalesPersonRoute && x.UserId == user.Id);
                        if (setting == null)
                        {
                            _notificationSettingsRepo.Insert(new NotificationSettings
                            {
                                UserId = user.Id,
                                NotificationType = NotficationEnums.SalesPersonRoute
                            });
                        }
                    }
                }
                else
                {
                    if (user.Role.Name == Roles.Admin.GetDescription())
                    {
                        var setting = _notificationSettingsRepo.FindBy(x => x.NotificationType == NotficationEnums.SalesPerson && x.UserId == user.Id);
                        if (setting != null)
                        {
                            _notificationSettingsRepo.Delete(setting);
                        }
                    }
                    else
                    {
                        var setting = _notificationSettingsRepo.FindBy(x => x.NotificationType == NotficationEnums.SalesPersonRoute && x.UserId == user.Id);
                        if (setting != null)
                        {
                            _notificationSettingsRepo.Delete(setting);
                        }
                    }
                }
                if (MmNotification)
                {
                    if (user.Role.Name == Roles.Admin.GetDescription())
                    {
                        var setting = _notificationSettingsRepo.FindBy(x => x.NotificationType == NotficationEnums.MarketingManager && x.UserId == user.Id);
                        if (setting == null)
                        {
                            _notificationSettingsRepo.Insert(new NotificationSettings
                            {
                                UserId = user.Id,
                                NotificationType = NotficationEnums.MarketingManager
                            });
                        }
                    }
                    else
                    {
                        var setting = _notificationSettingsRepo.FindBy(x => x.NotificationType == NotficationEnums.CustomerAdded && x.UserId == user.Id);
                        if (setting == null)
                        {
                            _notificationSettingsRepo.Insert(new NotificationSettings
                            {
                                UserId = user.Id,
                                NotificationType = NotficationEnums.CustomerAdded
                            });
                        }
                    }
                }
                else
                {
                    if (user.Role.Name == Roles.Admin.GetDescription())
                    {
                        var setting = _notificationSettingsRepo.FindBy(x => x.NotificationType == NotficationEnums.MarketingManager && x.UserId == user.Id);
                        if (setting != null)
                        {
                            _notificationSettingsRepo.Delete(setting);
                        }
                    }
                    else
                    {
                        var setting = _notificationSettingsRepo.FindBy(x => x.NotificationType == NotficationEnums.CustomerAdded && x.UserId == user.Id);
                        if (setting != null)
                        {
                            _notificationSettingsRepo.Delete(setting);
                        }
                    }
                }

                return Ok(new
                {
                    Message = string.Format(SuccessMessageConstants.UpdateSuccess, "Notification Settings")
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
    }
}
