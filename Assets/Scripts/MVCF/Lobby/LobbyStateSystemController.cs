using System;
using System.Threading.Tasks;
using Systems.StateSystem;

namespace Ariel.MVCF
{
    public class LobbyStateSystemController : BaseController, IStateSystem<LobbyState>
    {
        private LobbyState _currentState;
        private BaseController _currentContentController;
        private BaseController _currentButtonController;

        public override void Init()
        {
            MoveToState(LobbyState.Tournaments);
        }

        public async Task MoveToState(LobbyState toState)
        {
            if (toState == _currentState) 
                return;
            
            if (_currentContentController != null)
                await _currentContentController.TransitionOut();
            
            _currentState = toState;

            switch (toState)
            {
                case LobbyState.Tournaments:
                    _currentContentController = Injector.GetInstance<TournamentsTabController>();
                    break;

                case LobbyState.Store:
                    // _currentContentController = Injector.GetInstance<StoreTabController>();
                    break;

                case LobbyState.Account:
                    // _currentContentController = Injector.GetInstance<AccountTabController>();

                    break;

                case LobbyState.Social:
                    // _currentContentController = Injector.GetInstance<CRMTabController>();

                    break;
            }

            _currentContentController.Init();
        }
    }

    public enum LobbyState
    {
        Tournaments,
        Store,
        Account,
        Social
    }
}
