using UnityEngine;

namespace Ariel.Systems
{
    // TODO this is w/o primitive optimization
    public static class LocalSaveSystem
    {
        // Given serializable object 
        public static void Save<T>(string saveKey, T serializableObject)
        {
            // We can use any Json converter here(UnityUtility/Newtonsoft...)
            string json = JsonUtility.ToJson(serializableObject);
            if (string.IsNullOrEmpty(json))
                Debug.Log("Failed serliza to Json, Save process fail");

            PlayerPrefs.SetString(saveKey, json);
            Debug.Log($"{saveKey} Successfully saved with a json:{json}");
        }

        public static T Load<T>(string saveKey)
        {
            string json = PlayerPrefs.GetString(saveKey);
            if (string.IsNullOrEmpty(json))
                Debug.Log("Key is empty, Load process fail");

            var data = JsonUtility.FromJson<T>(json);
            if (data == null)
                Debug.Log("Key Data cannot deserialized, Load process fail");

            Debug.Log($"{saveKey} Successfully loaded");
            return data;
        }
    }
}