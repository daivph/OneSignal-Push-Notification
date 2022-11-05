using System;
using Push_OneSignal.Models;
using OneSignal.RestAPIv3.Client;
using OneSignal.RestAPIv3.Client.Resources;
using OneSignal.RestAPIv3.Client.Resources.Notifications;
using System.Threading.Tasks;

namespace Push_OneSignal.Helper
{
    public class OneSignalPushNotificationHelper
    {
        public OneSignalPushNotificationHelper()
        {
        }

        public static async Task<NotificationCreateResult> OneSignalPushNotification(CreateNotificationModel request, Guid appId, string restKey)
        {
            OneSignalClient client = new OneSignalClient(restKey);
            var opt = new NotificationCreateOptions()
            {
                AppId = appId,
                IncludePlayerIds = request.PlayerIds,
                SendAfter = DateTime.Now.AddSeconds(0)
            };
            opt.Headings.Add(LanguageCodes.English, request.Title);
            opt.Contents.Add(LanguageCodes.English, request.Content);
            NotificationCreateResult result = await client.Notifications.CreateAsync(opt);
            return result;
        }

        public static async Task<NotificationViewResult> OneSignalViewResultPushNotification(PushResult pushResult, Guid appId, string restKey)
        {
            OneSignalClient client = new OneSignalClient(restKey);
            var opt = new NotificationViewOptions() { AppId = appId, Id = pushResult.Id };
            var result = await client.Notifications.ViewAsync(opt);
            return result;
        }
        public static async Task<string> OneSignalCancelPushNotification(string id, string appId, string restKey)
        {
            var client = new OneSignalClient(restKey);
            var opt = new NotificationCancelOptions()
            {
                AppId = appId,
                Id = id
            };
            NotificationCancelResult result = await client.Notifications.CancelAsync(opt);
            return result.Success;
        }
    }
}

