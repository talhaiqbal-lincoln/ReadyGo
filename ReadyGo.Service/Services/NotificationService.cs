using Microsoft.AspNetCore.Identity;
using ReadyGo.Domain.Entities;
using ReadyGo.Domain.Entities.Identity;
using ReadyGo.Service.Interfaces;
using ReadyGo.Service.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ReadyGo.Domain.Enum;
using ReadyGo.Persistence.Seeds;

namespace ReadyGo.Service.Services
{
    public class NotificationService : INotificationService
    {

        private readonly IGenericRepository<Notification> _notificationRepo;
        private readonly IGenericRepository<UserNotification> _userNotificationRepo;
        private readonly IGenericRepository<Configuration> _configuration;
        private UserManager<ApplicationUser> _userManager;

        public NotificationService(UserManager<ApplicationUser> userManager, 
            IGenericRepository<Notification> notificationRepo, 
            IGenericRepository<UserNotification> userNotificationRepo,
            IGenericRepository<Configuration> configuration)
        {
            _userManager = userManager;
            _notificationRepo = notificationRepo;
            _userNotificationRepo = userNotificationRepo;
            _configuration = configuration;
        }

        public List<UserNotification> UserNotifications(string userId)
        {
            var notifications = _userNotificationRepo.FindAll(x => x.UserId.Equals(userId))
                .Include(x => x.Notification).ThenInclude(x => x.CreatedBy).OrderByDescending(x => x.Notification.CreatedAt).ToList();
            return notifications;
        }

        public void PushNotification(string content, string senderId, string redirectUrl, string module = null, string role = null, string userEmail = null)
        {
            Notification notification = new Notification
            {
                Content = content,
                CreatedAt = DateTime.Now,
                CreatedByid = senderId,
                RedirectUrl = redirectUrl
            };
            List<string> recieverRoles = new List<string>();
            List<string> recieverEmails = new List<string>();
            var userQuery = _userManager.Users.Include(x => x.NotificationSettings).
                Include(x => x.Role).Where(x => x.DeletedAt == null && x.Role != null);

            if (!string.IsNullOrEmpty(role))
            {
                recieverRoles = role.Split(',').ToList();
                userQuery = userQuery.Where(x => recieverRoles.Contains(x.Role.Name));
            }
            if (!string.IsNullOrEmpty(userEmail))
            {
                recieverEmails = userEmail.Split(',').ToList();
                userQuery = userQuery.Where(x => recieverEmails.Contains(x.Email));
            }

            var receivers = userQuery.ToList();

            var sender = _userManager.Users.Include(x => x.Role).First(x => x.Id.Equals(senderId));
            if (receivers.Count > 0)
            {
                _notificationRepo.Insert(notification);
                foreach (var user in receivers)
                {
                    if (user.Role.Name.Equals(Roles.Admin.GetDescription()))
                    {
                        var roleName = sender.Role.Name.Equals(Roles.SalesPerson.GetDescription()) ? "SalesPerson" : sender.Role.Name.Equals(Roles.SalesManager.GetDescription()) ? "SalesManager" : sender.Role.Name.Equals(Roles.MarketingManager.GetDescription()) ? "MarketingManager" : "Admin";
                        if (user.NotificationSettings.Any(x => x.NotificationType.ToString() == roleName) || roleName == "Admin")
                            _userNotificationRepo.Insert(new UserNotification
                            {
                                UserId = user.Id,
                                NotificationId = notification.Id
                            });
                    }
                    else
                    {
                        var permissions = _configuration.GetAll().ToList();
                        if (module != null)
                        {
                            if (module.Equals(NotficationEnums.CustomerAdded.ToString()) || module.Equals(NotficationEnums.DiscountedOrder.ToString()) || module.Equals(NotficationEnums.SalesPersonRoute.ToString()))
                            {
                                if(user.Role.Name == Roles.SalesManager.GetDescription())
                                {
                                    if (module.Equals(NotficationEnums.CustomerAdded.ToString()))
                                    {
                                        if (permissions.Where(x => x.ConfigKey == "Sales Manager_Customer").First().Value == "1")
                                        {
                                            if (user.NotificationSettings.Any(x => x.NotificationType.ToString() == module))
                                                _userNotificationRepo.Insert(new UserNotification
                                                {
                                                    UserId = user.Id,
                                                    NotificationId = notification.Id
                                                });
                                        }
                                    }
                                    else if (module.Equals(NotficationEnums.SalesPersonRoute.ToString()))
                                    {
                                        if(permissions.Where(x => x.ConfigKey == "Sales Manager_SalesPerson").First().Value == "1")
                                        {
                                            if (user.NotificationSettings.Any(x => x.NotificationType.ToString() == module))
                                                _userNotificationRepo.Insert(new UserNotification
                                                {
                                                    UserId = user.Id,
                                                    NotificationId = notification.Id
                                                });
                                        }
                                    }
                                    else
                                    {
                                        if (user.NotificationSettings.Any(x => x.NotificationType.ToString() == module))
                                            _userNotificationRepo.Insert(new UserNotification
                                            {
                                                UserId = user.Id,
                                                NotificationId = notification.Id
                                            });
                                    }
                                }
                                else
                                {
                                    if (user.Role.Name == Roles.MarketingManager.GetDescription())
                                    {
                                        if (module.Equals(NotficationEnums.CustomerAdded.ToString()))
                                        {
                                            if (permissions.Where(x => x.ConfigKey == "Marketing Manager_Customer").First().Value == "1")
                                            {
                                                if (user.NotificationSettings.Any(x => x.NotificationType.ToString() == module))
                                                    _userNotificationRepo.Insert(new UserNotification
                                                    {
                                                        UserId = user.Id,
                                                        NotificationId = notification.Id
                                                    });
                                            }
                                        }
                                        else if (module.Equals(NotficationEnums.SalesPersonRoute.ToString()))
                                        {
                                            if (permissions.Where(x => x.ConfigKey == "Marketing Manager_SalesPerson").First().Value == "1")
                                            {
                                                if (user.NotificationSettings.Any(x => x.NotificationType.ToString() == module))
                                                    _userNotificationRepo.Insert(new UserNotification
                                                    {
                                                        UserId = user.Id,
                                                        NotificationId = notification.Id
                                                    });
                                            }
                                        }
                                        else
                                        {
                                            if (user.NotificationSettings.Any(x => x.NotificationType.ToString() == module))
                                                _userNotificationRepo.Insert(new UserNotification
                                                {
                                                    UserId = user.Id,
                                                    NotificationId = notification.Id
                                                });
                                        }
                                    }
                                }
                            }
                        }
                        else
                        {
                            _userNotificationRepo.Insert(new UserNotification
                            {
                                UserId = user.Id,
                                NotificationId = notification.Id
                            });
                        }
                    }
                }
            }
        }

        public string GetTimeSpan(DateTime time)
        {
            const int SECOND = 1;
            const int MINUTE = 60 * SECOND;
            const int HOUR = 60 * MINUTE;
            const int DAY = 24 * HOUR;
            const int MONTH = 30 * DAY;

            var ts = DateTime.Now - time;
            double delta = Math.Abs(ts.TotalSeconds);

            if (delta < 1 * MINUTE)
                return ts.Seconds == 1 ? "1 second ago" : ts.Seconds + " seconds ago";

            if (delta < 2 * MINUTE)
                return "1 minute ago";

            if (delta < 45 * MINUTE)
                return ts.Minutes + " minutes ago";

            if (delta < 90 * MINUTE)
                return "1 hour ago";

            if (delta < 24 * HOUR)
                return ts.Hours + " hours ago";

            if (delta < 48 * HOUR)
                return "yesterday";

            if (delta < 30 * DAY)
                return ts.Days + " days ago";

            if (delta < 12 * MONTH)
            {
                int months = Convert.ToInt32(Math.Floor((double)ts.Days / 30));
                return months <= 1 ? "1 month ago" : months + " months ago";
            }
            else
            {
                int years = Convert.ToInt32(Math.Floor((double)ts.Days / 365));
                return years <= 1 ? "2 year ago" : years + " years ago";
            }
        }
    }
}
