using System;
using System.Threading.Tasks;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Utilities;

namespace ArielSystems
{
    public class SceneSystem : Singleton<SceneSystem>
    {
        [SerializeField] private GameObject _loadingBar;
        [SerializeField] private Image _loadingBarFillImage;
        [SerializeField] private TMP_Text _loadingBarPercentage;
    
        public async Task MoveToScene(SceneName sceneName, Action onSceneLoaded = null)
        {
            var activeScene = SceneManager.GetActiveScene();
        
            _loadingBar.SetActive(true);
            SetLoadingBarPercentage(1);
        
            AsyncOperation asyncOperation = SceneManager.LoadSceneAsync(sceneName.ToString(), LoadSceneMode.Additive);
            asyncOperation.allowSceneActivation = false;
        
            while (asyncOperation.progress < 0.9f)
            {
                Debug.Log($"Loading {sceneName} Scene...");
                SetLoadingBarPercentage(asyncOperation.progress + 0.1f);
                await Task.Delay(10);
            }
        
            _loadingBar.SetActive(false);
            asyncOperation.allowSceneActivation = true;
            Debug.Log($"Scene {sceneName} Loaded");
        

            while (!asyncOperation.isDone)
            {
            
                await Task.Delay(10);
            }
        
            SceneManager.UnloadSceneAsync(activeScene);
            Debug.Log($"Scene {activeScene.name} Unloaded");
            onSceneLoaded?.Invoke();
        }

        private void SetLoadingBarPercentage(float percentage)
        {
            _loadingBarFillImage.fillAmount = percentage;
            _loadingBarPercentage.text = (percentage * 100).ToString("N0");
        }
    }

    public enum SceneName
    {
        Boot,
        Main,
        Game
    }
}