using UnityEngine;

namespace Ariel.Systems
{
    public class PopupSystem
    {
        public static void ShowErrorPopUp(PopupController errorPopup)
        {
            PopupSystemView.AddPopupToQueue(errorPopup);
        }

        public static void ShowPopup(PopupController popup)
        {
            Debug.Log($"Popup raised here: {popup.Header}");
        }
    }
}
