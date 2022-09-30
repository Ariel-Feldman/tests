using System.Threading.Tasks;
using Ariel.Utilities;
using Ariel.MVCF;
using UnityEngine;

namespace Ariel.Systems
{
    public class NavSystem : Singleton<NavSystem>
    {
        private static NavState _currentState;
        private static BaseController _currentController;
        
        public static async Task MoveTo(NavState state)
        {
            if (state == _currentState) return;
            _currentState = state;
            
            await TransitionOut();
            
            switch (state)
            {
                case NavState.Lobby:
                    _currentController = Injector.GetInstance<LobbyController>();
                    break;
                case NavState.Store:
                    break;
                case NavState.Account:
                    break;
                case NavState.CRM:
                    break;
            }
        }

        private static async Task TransitionOut()
        {
            if (_currentController == null) return;
            Debug.Log("Awaiting For Transition Out");
            await Task.Delay(1000);
            // await _currentController.TransitionOut();
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
