using System;
namespace Push_OneSignal.Models
{
    public class CreateNotificationModel
    {
        public CreateNotificationModel()
        {
        }
        public string Title { get; set; }
        public string Content { get; set; }
        public List<string> PlayerIds { get; set; }
    }
}

