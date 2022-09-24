using System;
using System.Net;
using System.Threading.Tasks;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Ariel.Utilities;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.ResourceProviders;
using UnityEngine.SceneManagement;

namespace Ariel.Systems
{
    public class SceneSystem : Singleton<SceneSystem>
    {
        [SerializeField] private GameObject _loadingBar;
        [SerializeField] private Image _loadingBarFillImage;
        [SerializeField] private TMP_Text _loadingBarPercentage;

        [SerializeField] private AssetReference[] _sceneAssetsReferences;
        private SceneInstance _lastHandle;

        public async Task MoveToScene(SceneType sceneType)
        {
            var handle = Addressables.LoadSceneAsync(_sceneAssetsReferences[(int)sceneType], LoadSceneMode.Additive, false);

            _loadingBar.SetActive(true);
            SetLoadingBarPercentage(1);
            
            while (handle.PercentComplete < 0.9f)
            {
                Debug.Log($"Loading {sceneType} Scene...");
                SetLoadingBarPercentage(handle.PercentComplete);
                await Task.Delay(10);
            }
                
            _loadingBar.SetActive(false);
            handle.Result.ActivateAsync();
            
            while (!handle.IsDone)
            {
                Debug.Log($"Waiting for its is done");
                await Task.Delay(10);
            }

            if (_lastHandle.Scene != null)
            {
                Debug.Log($"Scene {_lastHandle.Scene.name} Unloaded");
                Addressables.UnloadSceneAsync(_lastHandle);
            }

            _lastHandle = handle.Result;
            
            
            //

            //
            //
            // AsyncOperation asyncOperation = SceneManager.LoadSceneAsync(sceneName.ToString(), LoadSceneMode.Additive);
            // asyncOperation.allowSceneActivation = false;
            //
            // while (asyncOperation.progress < 0.9f)
            // {
            //     Debug.Log($"Loading {sceneName} Scene...");
            //     SetLoadingBarPercentage(asyncOperation.progress + 0.1f);
            //     await Task.Delay(10);
            // }
            //
            // _loadingBar.SetActive(false);
            // asyncOperation.allowSceneActivation = true;
            // Debug.Log($"Scene {sceneName} Loaded");
            //
            //
            // while (!asyncOperation.isDone)
            // {
            //
            //     await Task.Delay(10);
            // }
            //
            // SceneManager.UnloadSceneAsync(activeScene);
            // Debug.Log($"Scene {activeScene.name} Unloaded");
        }

        private void SetLoadingBarPercentage(float percentage)
        {
            _loadingBarFillImage.fillAmount = percentage;
            _loadingBarPercentage.text = (percentage * 100).ToString("N0");
        }
    }

    public enum SceneType
    {
        Boot,
        Main,
        Game
    }
}