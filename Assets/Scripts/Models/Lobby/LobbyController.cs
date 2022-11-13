namespace Ariel.Models
{
    public class LobbyController : BaseController
    {
        public override void Init()
        {
            var resourceBarController = CreateController<ResourceBarController>();
            resourceBarController.Init();

            var lobbyStateController = CreateController<LobbyStateController>();
            lobbyStateController.Init();
        }
    }
}
