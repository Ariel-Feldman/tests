using System.Threading.Tasks;
using Ariel.Utilities;
using Ariel.MVCF;

namespace Ariel.Systems
{
    public class NavSystem : Singleton<NavSystem>
    {
        private static NavState _currentState;
        private static BaseController _currentController;
        
        public static async Task MoveTo(NavState state)
        {
            if (state == _currentState) return;

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
            await _currentController.TransitionOut();
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
