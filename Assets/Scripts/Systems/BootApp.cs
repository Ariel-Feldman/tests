using System.Threading.Tasks;
using Services;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Systems
{
    public class BootApp : MonoBehaviour
    {
        private void Awake()
        {
            LocalConfigs.SetQualitySettings();
            Boot();
        }

        private async Task Boot()
        {
            DebugSystem.Log("Boot Started");
            await ServiceResolver.InitServices();
            // await SceneSystem.Instance.MoveToScene(SceneName.Game);
            DebugSystem.Log("Boot Ended");
        }
    }
}
