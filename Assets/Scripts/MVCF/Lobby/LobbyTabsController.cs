using System.Threading.Tasks;

namespace Ariel.MVCF
{
    public class LobbyTabsController : BaseController
    {
        private LobbyNavState _currentState;
        private BaseController _currentContentController;
        private BaseController _currentButtonController;

        public override void Init()
        {
            MoveTo(LobbyNavState.Tournaments);
        }

        public async Task MoveTo(LobbyNavState state)
        {
            if (state == _currentState) return;
            _currentState = state;

            await CurrentStateTransitionOut();

            switch (state)
            {
                case LobbyNavState.Tournaments:
                    _currentContentController = Injector.GetInstance<TournamentsTabController>();
                    break;

                case LobbyNavState.Store:
                    break;

                case LobbyNavState.Account:
                    break;

                case LobbyNavState.CRM:
                    break;
            }

            _currentContentController.Init();
        }
        
        private async Task CurrentStateTransitionOut()
        {
            if (_currentContentController == null) return;
            await _currentContentController.TransitionOut();
        }
    }

    public enum LobbyNavState
    {
        Tournaments,
        Store,
        Account,
        CRM
    }
}
