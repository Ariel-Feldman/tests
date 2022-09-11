using System;
using System.Globalization;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using UnityEngine;

namespace Services
{
    public static class NetworkService
    {
        private static readonly HttpClient _client = new();

        public static async Task<bool> CheckGlobalConnection()
        {
            if (Application.internetReachability == NetworkReachability.NotReachable)
            {
                DebugSystem.Log("Internet Base Check fail");
                return false;
            }

            try
            {
                HttpResponseMessage response = await _client.GetAsync("http://www.contoso.com/");
                response.EnsureSuccessStatusCode();
                string responseBody = await response.Content.ReadAsStringAsync();
                
                DebugSystem.Log($"Web Request Passed with response body: {responseBody}");
                return true;
            }
            catch (HttpRequestException e)
            {
                DebugSystem.Log($"Internet CheckException Caught! Message :{e.Message} ");
                return false;
            }
        }

        private static string GetWierdURL()
        {
            var url = CultureInfo.InstalledUICulture switch
             {
                 { Name: var n } when n.StartsWith("fa") => // Iran
                     "http://www.aparat.com",
                 { Name: var n } when n.StartsWith("zh") => // China
                     "http://www.baidu.com",
                 _ =>
                     "http://www.gstatic.com/generate_204",
             };
            return url;
        }
    }
}
