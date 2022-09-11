using System;
using UnityEngine;

namespace Utilities.Serialization
{
    public class UnityJsonSerializer : ISerializationOption
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
                Debug.LogError($"Could not parse Json response {text}. {ex.Message}");
                return default;
            }
        }
    }
}
