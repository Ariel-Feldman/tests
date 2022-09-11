using Services;
using UnityEngine;

namespace Systems
{
    public class BootApp : MonoBehaviour
    {
        private void Awake()
        {
            DebugSystem.Log("Boot System Awake");
            Boot();
        }

        private async void Boot()
        {
            DebugSystem.Log("Loading configs");
            LocalConfigs.SetEmbeddedConfigs();

            DebugSystem.Log("Checkin network connection");
            if (!await NetworkService.CheckGlobalConnection())
            {
                ShowNoConnectionErrorPopup();
                return;
            }
            
            
            DebugSystem.Log("Initialize Service");
            if (!await ServiceResolver.InitServices())
            {
                ShowServiceDownErrorPopup();
            }
            
            await SceneSystem.Instance.MoveToScene(SceneName.Game);
            DebugSystem.Log("Boot Ended");
        }

        private void ShowNoConnectionErrorPopup()
        {
            var errorPopup = new PopupBase();
            errorPopup.Header = "O No!";
            errorPopup.Body = "Looks like you connection is down \n Click to restart!";
            errorPopup.SetActionButton("Restart", Boot);
            PopupSystem.ShowErrorPopUp(errorPopup);
        }
        
        private void ShowServiceDownErrorPopup()
        {
            var errorPopup = new PopupBase();
            errorPopup.Header = "Services are down!";
            errorPopup.Body = "Services are down!!! \n Click to restart!";
            errorPopup.SetActionButton("Restart App", Boot);
            PopupSystem.ShowErrorPopUp(errorPopup);
        }
    }
}
