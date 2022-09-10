using System;
using System.Threading.Tasks;
using Services;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Systems
{
    public class BootApp : MonoBehaviour
    {
        [SerializeField] private Image _loadingBarFillImage;
        [SerializeField] private TMP_Text _loadingBarPercentage;
        
        private void Awake()
        {
            SetLoadingBarPercentage(0);
            LocalConfigs.SetQualitySettings();
            Boot();
        }

        private async Task Boot()
        {
            if (!await ServiceResolver.InitServices())
            {
            }
            

            AsyncOperation ao = SceneManager.LoadSceneAsync(1, LoadSceneMode.Additive);
        }

        private void SetLoadingBarPercentage(int percentage)
        {
            _loadingBarFillImage.fillAmount = percentage;
            _loadingBarPercentage.text = (percentage * 100).ToString("N0");
        }
    }
}
