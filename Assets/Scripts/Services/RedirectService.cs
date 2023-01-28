using Ariel.Features;
using Ariel.Utilities;

namespace Ariel.Services
{
    public static class RedirectService
    {
        public static void BootEnded()
        {
            // deeplink/ PushNotification flow here...
            
            var lobbyController = Injector.GetInstance<LobbyController>();
            lobbyController.Init();
        }
    }
}
