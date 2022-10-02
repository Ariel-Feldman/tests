using System.Threading.Tasks;
using Ariel.Utilities;
using Ariel.MVCF;
using UnityEngine;

namespace Ariel.Systems
{
    public class NavSystem : Singleton<NavSystem>
    {
        private static NavState _currentState;
        private static StateController _currentStateController;
        
        public static async Task MoveTo(NavState state)
        {
            if (state == _currentState) return;
            _currentState = state;
            
            await CurrentStateTransitionOut();
            
            switch (state)
            {
                case NavState.Lobby:
                    _currentStateController = Injector.GetInstance<LobbyController>();
                    break;
                
                case NavState.Store:
                    break;
                
                case NavState.Account:
                    break;
                
                case NavState.CRM:
                    break;
            }
            
            _currentStateController.BindViews();
            _currentStateController.Init();
        }


        private static async Task CurrentStateTransitionOut()
        {
            if (_currentStateController == null) return;
            Debug.Log("Awaiting For Transition Out");
            await Task.Delay(333);
            await _currentStateController.StateTransitionOut();
        }
    }
    
    public enum NavState
    {
        Boot,
        Lobby,
        Store,
        Account,
        CRM
    }
}
