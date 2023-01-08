using System;
using UnityEngine;

namespace Ariel.Utilities.Serialization
{
    public class UnityJsonSerializer : ISerializer
    {
        public string ContentType => "application/json";
        public T Deserialize<T>(string text)
        {
            try
            {
                // var result = JsonConvert.DeserializeObject<T>(text);
                var result = JsonUtility.FromJson<T>(text);
                return result;
            }
            catch (Exception ex)
            {
                UnityEngine.Debug.LogError($"Could not parse Json response {text}. {ex.Message}");
                return default;
            }
        }
        
        public string Serialize<T>(T DataObject)
        {
            try
            {
                // var result = JsonConvert.DeserializeObject<T>(text);
                var result = JsonUtility.ToJson(DataObject);
                return result;
            }
            catch (Exception ex)
            {
                Debug.LogError($"Could not parse Json response {DataObject}. {ex.Message}");
                return default;
            }
        }
    }
}
