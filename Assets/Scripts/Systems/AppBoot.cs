using Ariel.Config;
using Ariel.MVCF;
using Ariel.Services;

namespace Ariel.Systems
{
    public static class AppBoot 
    {
        public static async void Boot()
        {
            LocalConfigs.SetEmbeddedConfigs();
            Injector.ClearInstances();
            ViewSystem.Init();
            
            // if (!await ServicesInitializer.InitServices())
            // {
            //     ShowServiceDownErrorPopup();
            //     return;
            // }
            
            // if (!await Injector.GetInstance<HttpService>().CheckGlobalConnection())
            // {
            //     ShowNoConnectionErrorPopup();
            //     return;
            // }
            
            await SceneSystem.Instance.MoveToScene(SceneType.Main);
            
            var DesiredNavStateOnBoot = NavState.Lobby; // Redirection system kick here?
            
            await NavSystem.MoveTo(DesiredNavStateOnBoot);
        }
        
        private static void ShowNoConnectionErrorPopup()
        {
            var errorPopup = new PopupBase();
            errorPopup.Header = "O No!";
            errorPopup.Body = "Looks like you connection is down \n Click to restart!";
            errorPopup.SetActionButton("Restart", Boot);
            PopupSystem.ShowErrorPopUp(errorPopup);
        }
        
        private static void ShowServiceDownErrorPopup()
        {
            var errorPopup = new PopupBase();
            errorPopup.Header = "Services are down!";
            errorPopup.Body = "Services are down!!! \n Click to restart!";
            errorPopup.SetActionButton("Restart App", Boot);
            PopupSystem.ShowErrorPopUp(errorPopup);
        }
    }
}
