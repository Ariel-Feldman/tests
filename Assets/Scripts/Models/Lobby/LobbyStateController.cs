using System.Threading.Tasks;
using Systems.Models;

namespace Ariel.Models
{
    public class LobbyStateController : BaseController, IStateController<LobbyState>
    {
        private LobbyState _currentState;
        private BaseController _currentContentController;
        private BaseController _currentButtonController;

        private LobbyStateView _view;

        protected override void BindViews()
        {
            _view = BindView<LobbyStateView>();
        }

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
                    _currentContentController = CreateController<TournamentsTabController>();
                    break;

                case LobbyState.Store:
                    // _currentContentController = GetController<StoreTabController>();
                    break;

                case LobbyState.Account:
                    // _currentContentController = GetController<AccountTabController>();

                    break;

                case LobbyState.Social:
                    // _currentContentController = GetController<CRMTabController>();

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
