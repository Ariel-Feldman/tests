using Ariel.Config;
using Ariel.Models;
using Ariel.Systems;

namespace Ariel.Models
{
    public static class AppBoot 
    {
        public static async void Boot()
        {
            LocalConfigs.SetEmbeddedConfigs();
            Injector.ClearInstances();
            SceneViews.Init();
            
            // if (!await HttpService.SetHttpClient())
            // {
            //     ShowNoConnectionErrorPopup();
            //     return;
            // }
            //
            // if (!await ServicesInitializer.InitServices())
            // {
            //     ShowServiceDownErrorPopup();
            //     return;
            // }
            //
            
            await SceneSystem.Instance.LoadScene(SceneType.Main);
            RedirectSystem.BootEnded();
        }
        
        private static void ShowNoConnectionErrorPopup()
        {
            
            var errorPopup = new PopupController();
            errorPopup.Header = "O No!";
            errorPopup.Body = "Looks like you connection is down \n Click to restart!";
            errorPopup.SetActionButton("Restart", Boot);
            PopupSystem.ShowErrorPopUp(errorPopup);
        }
        
        private static void ShowServiceDownErrorPopup()
        {
            var errorPopup = new PopupController();
            errorPopup.Header = "Services are down!";
            errorPopup.Body = "Services are down!!! \n Click to restart!";
            errorPopup.SetActionButton("Restart App", Boot);
            PopupSystem.ShowErrorPopUp(errorPopup);
        }
    }
}
