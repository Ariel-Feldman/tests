using System.Threading.Tasks;
using Ariel.Systems;
using Debug = UnityEngine.Debug;

namespace Ariel.MVCF
{
    public class LobbyController : BaseController
    {
        private LobbyView _view;
        private TournamentsController _tournamentsController;
        public async void Init()
        {
            // Debug.Log("Lobby Controller View Bind");
            // _view = ViewResolver.GetView<LobbyView>();
            //
            Debug.Log("qqq awaiting frames");
            await MonoSystem.Instance.AwaitFrames(220);
            Debug.Log("qqq waited 220 frames");
            
            // _tournamentsController = Resolver.GetController<TournamentsController>();
            // await _tournamentsController.ShowTournaments();
        }
    }
}
