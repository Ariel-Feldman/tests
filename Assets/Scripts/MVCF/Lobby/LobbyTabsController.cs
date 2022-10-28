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
            if (state == _currentState) 
                return;
            
            _currentState = state;

            if (_currentContentController != null)
                await _currentContentController.TransitionOut();

            switch (state)
            {
                case LobbyNavState.Tournaments:
                    _currentContentController = Injector.GetInstance<TournamentsTabController>();
                    break;

                case LobbyNavState.Store:
                    // _currentContentController = Injector.GetInstance<StoreTabController>();
                    break;

                case LobbyNavState.Account:
                    // _currentContentController = Injector.GetInstance<AccountTabController>();

                    break;

                case LobbyNavState.CRM:
                    // _currentContentController = Injector.GetInstance<CRMTabController>();

                    break;
            }

            _currentContentController.Init();
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
