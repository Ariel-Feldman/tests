using System.Threading.Tasks;
using Ariel.Utilities;
using Ariel.MVCF;
using UnityEngine;

namespace Ariel.Systems
{
    public class LobbyNavSystem : Singleton<LobbyNavSystem>
    {
        private static LobbyNavState _currentState;
        private static BaseController _currentTabController;
        
        public static async Task MoveTo(LobbyNavState state)
        {
            if (state == _currentState) return;
            _currentState = state;
            
            await CurrentStateTransitionOut();
            
            switch (state)
            {
                case LobbyNavState.Tournaments:
                    _currentTabController = Injector.GetInstance<TournamentsTabController>();
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


        private static async Task CurrentStateTransitionOut()
        {
            if (_currentTabController == null) return;
            Debug.Log("Awaiting For Transition Out");
            await Task.Delay(333);
            // await _currentTabController.StateTransitionOut();
        }
    }
    
}

public enum LobbyNavState
{
    Boot,
    Tournaments,
    Store,
    Account,
    CRM
}
