using System;
using System.Net.Http;
using System.Threading.Tasks;
using Ariel.Utilities;
using Ariel.Utilities.Serialization;
using UnityEngine;
using UnityEngine.Networking;

namespace Ariel.Services
{
    public static class HttpService
    {
        private static HttpClient _client;
        private static ISerializer _serializer;

        private const string TestAddress = "http://www.google.com/";
        
        public static async Task<bool> SetHttpClient()
        {
            _client = new HttpClient();
            _serializer = new UnityJsonSerializer();
            
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
        
        public static async Task<T> Get<T>(string url)
        {
            try
            {
                using var www = UnityWebRequest.Get(url);
                www.SetRequestHeader("Content-Type", _serializer.ContentType);
                var operation = www.SendWebRequest();
                
                while (!operation.isDone)
                    await Task.Yield();

                if (www.result != UnityWebRequest.Result.Success)
                    Debug.LogError($"UnityWebRequest Failed: {www.error}");
                
                var result = _serializer.Deserialize<T>(www.downloadHandler.text);
                return result;
            }
            catch (Exception ex)
            {
                // Show no internet popup here
                Debug.LogError($"{nameof(Get)} (UnityWebRequest) failed: {ex.Message}");
                return default;
            }
        }
    }
}
