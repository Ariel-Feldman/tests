using UnityEngine;

namespace Ariel.Systems
{
    public static class PopupSystem
    {
        public static void ShowErrorPopUp(BasePopup errorBasePopup)
        {
            PopupSystemView.Instance.ShowNextPopup(errorBasePopup);
        }

        public static void ShowPopup(BasePopup basePopup)
        {
            Debug.Log($"Popup raised here: {basePopup.Header}");
        }
    }
}
