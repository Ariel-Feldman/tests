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
        public static SceneType CurrentScene { get; private set; }
        
        [SerializeField] private GameObject _loadingBar;
        [SerializeField] private Image _loadingBarFillImage;
        [SerializeField] private TMP_Text _loadingBarPercentage;

        [SerializeField] private GameObject _bootSceneCamera;
        
        [SerializeField] private AssetReference[] _sceneAssetsReferences;
        private SceneInstance _lastHandle;
        
        public async Task MoveToScene(SceneType sceneType)
        {
            var loadSceneOperation = Addressables.LoadSceneAsync(_sceneAssetsReferences[(int)sceneType], LoadSceneMode.Additive, false);

            _loadingBar.SetActive(true);
            SetLoadingBarPercentage(0);
            
            while (!loadSceneOperation.IsDone)
            {
                SetLoadingBarPercentage(loadSceneOperation.PercentComplete);
                await Task.Delay(10);
            }

            var activeScene = SceneManager.GetActiveScene();
            var activateOperation = loadSceneOperation.Result.ActivateAsync();
            while (!activateOperation.isDone)
            {
                SetLoadingBarPercentage(loadSceneOperation.PercentComplete + activateOperation.progress);
                await Task.Delay(10);
            }

            if (CurrentScene == SceneType.Boot)
                SceneManager.UnloadSceneAsync(activeScene);
            else
                Addressables.UnloadSceneAsync(_lastHandle);
            
            _lastHandle = loadSceneOperation.Result;
            CurrentScene = sceneType;
            
            ViewSystem.ResolveSceneViews();
            _loadingBar.SetActive(false);
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