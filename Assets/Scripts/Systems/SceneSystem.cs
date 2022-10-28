using System.Threading.Tasks;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Ariel.Utilities;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;
using UnityEngine.ResourceManagement.ResourceProviders;
using UnityEngine.SceneManagement;

namespace Ariel.Systems
{
    public class SceneSystem : Singleton<SceneSystem>
    {
        public static SceneType CurrentScene { get; private set; }
        
        [SerializeField] private GameObject _loadingBar;
        [SerializeField] private Image _loadingBarFillImage;
        [SerializeField] private TMP_Text _loadingBarPercentage;
        [SerializeField] private AssetReference[] _sceneAssetReferences;
        
        private SceneInstance _lastHandle;
        
        public async Task LoadScene(SceneType sceneType)
        {
            SetLoadingUiVisible(true);
            
            var loadSceneOperation = Addressables.LoadSceneAsync(_sceneAssetReferences[(int)sceneType], LoadSceneMode.Additive, false);
            await LoadSceneOperation(loadSceneOperation);
            await SwipeActiveScene(loadSceneOperation);
            
            CurrentScene = sceneType;
            SceneViews.MapSceneViews();
            
            SetLoadingUiVisible(false);
        }

        private void SetLoadingUiVisible(bool isVisible)
        {
            _loadingBar.SetActive(isVisible);
            SetLoadingBarPercentage(0);
        }

        private async Task LoadSceneOperation(AsyncOperationHandle<SceneInstance> loadSceneOperation)
        {
            while (!loadSceneOperation.IsDone)
            {
                SetLoadingBarPercentage(loadSceneOperation.PercentComplete);
                await Task.Delay(10);
            }
        }

        private async Task SwipeActiveScene(AsyncOperationHandle<SceneInstance> loadSceneOperation)
        {
            var activateOperation = loadSceneOperation.Result.ActivateAsync();
            while (!activateOperation.isDone)
            {
                SetLoadingBarPercentage(loadSceneOperation.PercentComplete + activateOperation.progress);
                await Task.Delay(10);
            }
            
            if (CurrentScene == SceneType.Boot)
                SceneManager.UnloadSceneAsync(SceneManager.GetActiveScene());
            else
                Addressables.UnloadSceneAsync(_lastHandle);
            
            _lastHandle = loadSceneOperation.Result;
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