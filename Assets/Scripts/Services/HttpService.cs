using System;
using System.Net.Http;
using System.Threading.Tasks;
using Ariel.Utilities;
using Ariel.Utilities.Serialization;
using UnityEngine;
using UnityEngine.Networking;

namespace Ariel.Services
{
    public class HttpService 
    {
        private static HttpClient _client;
        private static ISerializationOption _serializationOption;

        public void InitClient()
        {
            _client = new HttpClient();
            _serializationOption = new UnityJsonSerializer();
        }
        
        public void SetSerializer(ISerializationOption serializationOption)
        {
            _serializationOption = serializationOption;
        }

        public async Task<bool> CheckGlobalConnection()
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
        
        public async Task<T> Get<T>(string url)
        {
            try
            {
                using var www = UnityWebRequest.Get(url);
                www.SetRequestHeader("Content-Type", _serializationOption.ContentType);
                var operation = www.SendWebRequest();
                
                while (!operation.isDone)
                    await Task.Yield();

                if (www.result != UnityWebRequest.Result.Success)
                    Debug.LogError($"UnityWebRequest Failed: {www.error}");
                
                var result = _serializationOption.Deserialize<T>(www.downloadHandler.text);
                return result;
            }
            catch (Exception ex)
            {
                // Show no internet popup here
                Debug.LogError($"{nameof(Get)} (UnityWebRequest) failed: {ex.Message}");
                return default;
            }
        }
        
        private const string TestAddress = "http://www.google.com/";
    }
}
