using MVCF;
using Utilities;

namespace Systems
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
                    // var lobbyController = FeatureResolver.GetFeature<LobbyController>();
                    break;
                case NavState.Store:
                    break;
                case NavState.Account:
                    break;
                case NavState.CRM:
                    break;
            }
            
            UnityEngine.Debug.Log("Nav System is working");
        }
    }


    public enum NavState
    {
        Lobby,
        Store,
        Account,
        CRM
    }
}
