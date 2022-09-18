using Utilities;
using ArielBase;
using ArielConcrete;

namespace ArielSystems
{
    public class NavSystem : Singleton<NavSystem>
    {
        private static NavState _currentState;
        
        public static void MoveTo(NavState state)
        {
            if (state == _currentState) return;
            switch (state)
            {
                case NavState.Lobby:
                    var lobbyController = Injector.GetController<LobbyController>();
                    lobbyController.Init();
                    break;
                case NavState.Store:
                    break;
                case NavState.Account:
                    break;
                case NavState.CRM:
                    break;
            }
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
