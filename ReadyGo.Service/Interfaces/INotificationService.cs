using ReadyGo.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ReadyGo.Service.Interfaces
{
    public interface INotificationService
    {
        void PushNotification(string content, string senderId, string redirectUrl, string module = null, string role = null, string user = null);
        List<UserNotification> UserNotifications(string userId);
        string GetTimeSpan(DateTime time);
    }
}
