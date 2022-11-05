using System;
using Microsoft.AspNetCore.Mvc;
using Push_OneSignal.Helper;
using Push_OneSignal.Models;

namespace Push_OneSignal.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NotificationController : ControllerBase
    {
        private readonly IConfiguration _configuration;

        public NotificationController(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        [HttpPost]
        public async Task<IActionResult> CreateNotification([FromBody] CreateNotificationModel request)
        {
            Guid appId = Guid.Parse(_configuration.GetSection(AppSettingKey.OneSignalAppId).Value);
            string restKey = _configuration.GetSection(AppSettingKey.OneSignalRestKey).Value;
            var result = await OneSignalPushNotificationHelper.OneSignalPushNotification(request, appId, restKey);
            return Ok(result);
        }

        [HttpPost("Result")]
        public async Task<IActionResult> GetNotificationResult([FromBody] PushResult pushResult)
        {
            Guid appId = Guid.Parse(_configuration.GetSection(AppSettingKey.OneSignalAppId).Value);
            string restKey = _configuration.GetSection(AppSettingKey.OneSignalRestKey).Value;
            var result = await OneSignalPushNotificationHelper.OneSignalViewResultPushNotification(pushResult, appId, restKey);
            return Ok(result);
        }
    }
}

