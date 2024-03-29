using Ariel.Config;
using Ariel.Services;
using Ariel.Systems;
using Ariel.Utilities;
using UnityEngine;

namespace Ariel.Features
{
    public static class AppBoot 
    {
        public static async void Boot()
        {
            LocalConfigs.SetEmbeddedConfigs();
            Injector.ClearInstances();
            SceneViewSystem.Init();
            
            // // if (!await HttpService.SetHttpClient())
            // {
            //     ShowNoConnectionErrorPopup();
            //     return;
            // }
            //
            if (!await ServicesInitializer.InitServices())
            {
                ShowServiceDownErrorPopup();
                return;
            }
            
            
            await SceneSystem.Instance.LoadScene(SceneType.Main);
            RedirectService.BootEnded();
        }
        
        private static void ShowNoConnectionErrorPopup()
        {
            
            var errorPopup = new BasePopupData();
            errorPopup.Header = "O No!";
            errorPopup.Body = "Looks like you connection is down \n Click to restart!";
            errorPopup.ActionButton("Restart", PrintDebugClick);
            PopupSystem.Instance.ShowErrorPopUp(errorPopup);
        }
        
        private static void ShowServiceDownErrorPopup()
        {
            var errorPopup = new BasePopupData();
            errorPopup.Header = "Services are down!";
            errorPopup.Body = "Services are down!!! \n Click to restart!";
            errorPopup.ActionButton("Restart App", PrintDebugClick);
            PopupSystem.Instance.ShowErrorPopUp(errorPopup);
        }
        
        private static void PrintDebugClick()
        {
            Debug.Log("Clicked...");
        }
    }
}
