using System.Net.Http;
using System.Threading.Tasks;
using UnityEngine;

namespace ArielServices
{
    public static class NetworkService
    {
        private const string TestAddress = "http://www.google.com/";
        
        private static readonly HttpClient _client = new();

        public static async Task<bool> CheckGlobalConnection()
        {
            if (Application.internetReachability == NetworkReachability.NotReachable)
                return false;
            try
            {
                // Simple
                HttpResponseMessage response = await _client.GetAsync(TestAddress);
                response.EnsureSuccessStatusCode();
                return true;
            }
            catch 
            {
                return false;
            }
        }
        // private static string GetWierdURL()
        // {
        //     var url = CultureInfo.InstalledUICulture switch
        //      {
        //          { Name: var n } when n.StartsWith("fa") => // Iran
        //              "http://www.aparat.com",
        //          { Name: var n } when n.StartsWith("zh") => // China
        //              "http://www.baidu.com",
        //          _ =>
        //              "http://www.gstatic.com/generate_204",
        //      };
        //     return url;
        // }
    }
}
