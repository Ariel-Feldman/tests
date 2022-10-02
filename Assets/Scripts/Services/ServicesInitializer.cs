using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Ariel.MVCF;
using UnityEngine;

namespace Ariel.Services
{
    public static class ServicesInitializer
    {
        private static TaskCompletionSource<bool> _tcs;

        public static async Task<bool> InitServices()
        {
            _tcs = new TaskCompletionSource<bool>();
            
            _tcs.SetResult(true);
            
            await _tcs.Task;
            
            return _tcs.Task.Result;
        }
    }
}
