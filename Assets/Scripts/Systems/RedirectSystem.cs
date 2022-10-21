using Ariel.MVCF;

namespace Ariel.Systems
{
    public static class RedirectSystem
    {
        public static async void BootEnded()
        {
            // deeplink/ PushNotification flow here...
            
            var lobbyController = Injector.GetInstance<LobbyController>();
            lobbyController.Init();
            
            await lobbyController.MoveTo(LobbyNavState.Tournaments);
        }
    }
}
