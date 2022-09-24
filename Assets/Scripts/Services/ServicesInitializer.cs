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

            var httpService = Injector.GetInstance<HttpService>();
            httpService.InitClient();
            
            await _tcs.Task;
            
            return _tcs.Task.Result;
        }
    }
}
