using System;
using System.IO;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.Networking;

namespace Parana
{
    public class HttpClient
    {
        private readonly ISerializationOption _serializationOption;

        public HttpClient(ISerializationOption serializationOption)
        {
            _serializationOption = serializationOption;
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
        
    }
}
