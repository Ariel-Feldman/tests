using System;
using System.Threading.Tasks;
using UnityEngine;

namespace Services
{

    public static class AnalyticsService
    {
        public static async Task Init(Action<Type, bool> onServiceAdded)
        {
            await Task.Delay(1500);
            onServiceAdded.Invoke(typeof(AnalyticsService), true);
        }
    }
}