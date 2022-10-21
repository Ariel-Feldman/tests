
using System.Threading.Tasks;
using UnityEngine;

namespace Ariel.MVCF
{
    public class LobbyController : BaseController
    {
        private static LobbyNavState _currentState;
        private static BaseController _currentTabController;
        
        private static BaseController _BottomNavBarController;
        
        public override void Init()
        {
            _BottomNavBarController = GetController<BottomBarController>();
            _BottomNavBarController.Init();
            
            Debug.Log("Bottom Bar Initialized");
        }
        
        public async Task MoveTo(LobbyNavState state)
        {
            if (state == _currentState) return;
            _currentState = state;
            
            await CurrentStateTransitionOut();
            
            switch (state)
            {
                case LobbyNavState.Tournaments:
                    _currentTabController = GetController<TournamentsTabController>();
                    break;
                
                case LobbyNavState.Store:
                    break;
                
                case LobbyNavState.Account:
                    break;
                
                case LobbyNavState.CRM:
                    break;
            }
            
            _currentTabController.Init();
        }
        
        private async Task CurrentStateTransitionOut()
        {
            if (_currentTabController == null) return;
            await _currentTabController.TransitionOutView();
        }
    }
}
