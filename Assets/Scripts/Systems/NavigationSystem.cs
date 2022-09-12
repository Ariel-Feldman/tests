using UnityEngine;
using Utilities;

namespace Systems
{
    public class NavigationSystem : Singleton<NavigationSystem>
    {
        public static void Test()
        {
            UnityEngine.Debug.Log("Nav System is working");
        }
    }
}
