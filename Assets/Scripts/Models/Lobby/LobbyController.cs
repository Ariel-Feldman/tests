namespace Ariel.Models
{
    public class LobbyController : BaseController
    {
        public override void Init()
        {
            var resourceBarController = GetController<ResourceBarController>();
            resourceBarController.Init();

            var lobbyStateController = GetController<LobbyStateController>();
            lobbyStateController.Init();
        }
    }
}
