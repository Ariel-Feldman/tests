using Ariel.Config;
using Ariel.Services;
using UnityEngine;

namespace Ariel.Systems
{
    public class BootApp : MonoBehaviour
    {
        private void Awake()
        {
            Debug.Log("Boot System Awake");
            Boot();
        }

        private async void Boot()
        {
            Debug.Log("Loading configs");
            LocalConfigs.SetEmbeddedConfigs();

            Debug.Log("Checking network connection");
            if (!await HttpService.CheckGlobalConnection())
            {
                Debug.Log("Network Check Fail");
                ShowNoConnectionErrorPopup();
                return;
            }
            
            
            Debug.Log("Initialize Services");
            if (!await ServiceResolver.InitServices())
            {
                ShowServiceDownErrorPopup();
                return;
            }
            
            Debug.Log("Boot Ended");
            await SceneSystem.Instance.MoveToScene(SceneName.Main, ShowLobby);
        }
        
        private void ShowLobby()
        {
            NavSystem.MoveTo(NavState.Lobby);
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
