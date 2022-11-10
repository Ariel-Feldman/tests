namespace Ariel.MVCF
{
    public class LobbyController : BaseController
    {
        public override void Init()
        {
            var resourceBarController = CreateController<ResourceBarController>();
            resourceBarController.Init();

            var lobbyStateController = CreateController<LobbyStateSystemController>();
            lobbyStateController.Init();
        }
    }
}
