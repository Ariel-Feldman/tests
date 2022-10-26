namespace Ariel.MVCF
{
    public class LobbyController : BaseController
    {
        public override void Init()
        {
            var resourceBarController = GetController<ResourceBarController>();
            resourceBarController.Init();

            var lobbyTabsController = GetController<LobbyTabsController>();
            lobbyTabsController.Init();
        }
    }
}
