using System.Collections.Generic;
using UnityEngine;
using Ariel.Utilities;

namespace Ariel.Systems
{
    public class PopupSystemView : Singleton<PopupSystemView>
    {

        private List<PopupController> _livePopups;

        public static void AddPopupToQueue(PopupController popupController)
        {
            // popupController.SetBasicContext(popupController);
            // var instantiatedPopup = Instantiate(popupView, transform);
            // _livePopups.Add(instan);
        }
        
    }
}
