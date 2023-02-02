using System.Collections.Generic;
using System.Threading.Tasks;
// using Unity.Notifications.iOS;

namespace Ariel.Services
{
    public static class PushNotificationService
    {
        private static Dictionary<string, string> _notifications = new();

        public static async Task Setup(string userID)
        {
            // var authorizationRequest = new AuthorizationRequest(AuthorizationOption.Provisional, DeviceService.IsIOS());
        }
    }
}
