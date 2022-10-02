
namespace Ariel.MVCF
{
    public class LobbyController : StateController
    {
        private LobbyView _view;
        
        public override void BindViews()
        {
            _view = BindView<LobbyView>();
            _liveViews.Add(_view);
        }

        public override void Init() 
        {
            var tournamentsController = Injector.GetInstance<TournamentsController>();
            // tournamentsController.BindViews();
            // tournamentsController.ShowTournaments();
        }
    }
}
