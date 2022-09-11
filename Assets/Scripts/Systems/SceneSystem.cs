using System;
using System.Threading.Tasks;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Utilities;

public class SceneSystem : Singleton<SceneSystem>
{
    [SerializeField] private Image _loadingBarFillImage;
    [SerializeField] private TMP_Text _loadingBarPercentage;
    
    public async Task MoveToScene(SceneName sceneName, Action onSceneLoaded = null)
    {
        SetLoadingBarPercentage(1);
        AsyncOperation asyncOperation = SceneManager.LoadSceneAsync((int)sceneName);
        asyncOperation.allowSceneActivation = false;
        while (!asyncOperation.isDone || asyncOperation.progress < 0.9f)
        {
            SetLoadingBarPercentage(asyncOperation.progress + 0.1f);
            await Task.Delay(10);
        }
        
        onSceneLoaded?.Invoke();
        asyncOperation.allowSceneActivation = true;
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
