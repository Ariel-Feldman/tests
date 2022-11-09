namespace Ariel.MVCF
{
    public class LobbyController : BaseController
    {
        public override void Init()
        {
            var resourceBarController = GetController<ResourceBarController>();
            resourceBarController.Init();

            var lobbyStateController = GetController<LobbyStateSystemController>();
            lobbyStateController.Init();
        }
    }
}
