using System;
using System.Threading.Tasks;
using Services;
using UnityEngine;

namespace Systems
{
    public class BootApp : MonoBehaviour
    {
        private void Awake()
        {
            Boot();
        }

        private async Task Boot()
        {
            if (!await ServiceResolver.InitServices())
            {
            }
            NavigationSystem.Test();
        }
    }
}
