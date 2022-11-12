using Ariel.Models;

namespace Ariel.Systems
{
    public static class RedirectSystem
    {
        public static void BootEnded()
        {
            // deeplink/ PushNotification flow here...
            
            var lobbyController = Injector.GetInstance<LobbyController>();
            lobbyController.Init();
        }
    }
}
