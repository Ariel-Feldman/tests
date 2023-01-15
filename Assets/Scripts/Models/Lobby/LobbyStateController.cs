using System.Threading.Tasks;
using Systems.Models;

namespace Ariel.Models
{
    public class LobbyStateController : BaseController, IStateController<LobbyState>
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
                    _currentContentController = GetController<TournamentsController>(this);
                    break;

                case LobbyState.Store:
                    // _currentContentController = GetController<StoreTabController>(this);
                    break;

                case LobbyState.Account:
                    // _currentContentController = GetController<AccountTabController>(this);

                    break;

                case LobbyState.Social:
                    // _currentContentController = GetController<CRMTabController>(this);

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
