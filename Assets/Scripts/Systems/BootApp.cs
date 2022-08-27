using Services;
using UnityEngine;

namespace Systems
{
    public class BootApp : MonoBehaviour
    {
        private void Awake()
        {
            ServiceResolver.InitServices();
            AppStateSystem.Test();
        }
    }
}
