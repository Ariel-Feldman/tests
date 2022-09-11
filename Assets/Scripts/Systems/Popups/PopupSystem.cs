using UnityEngine;

namespace Systems
{
    public class PopupSystem
    {
        public static void ShowErrorPopUp(PopupBase errorPopup)
        {
            DebugSystem.Log("Error popup to raise here");
            PopupSystemView.Instance.AddPopupToQueue(errorPopup);
        }
    }
}
