using UnityEngine;

namespace Ariel.Systems
{
    public class PopupSystem
    {
        public static void ShowErrorPopUp(PopupBase errorPopup)
        {
            Debug.Log("Error popup to raise here");
            // PopupSystemView.Instance.AddPopupToQueue(errorPopup);
        }

        public static void ShowPopup(PopupBase popup)
        {
            Debug.Log($"Popup raised here: {popup.Header}");
        }
    }
}
