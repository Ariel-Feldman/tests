using System.Collections.Generic;
using Ariel.Utilities;
using UnityEngine;

namespace Ariel.Systems
{
    public class PopupSystem : Singleton<PopupSystem>
    {
        [SerializeField] private PopupView _errorPopupView;
        
        private List<BasePopup> _popupQueue;

        public void CloseAllPopups()
        {
            _errorPopupView.gameObject.SetActive(false);
        }
        
        public void ShowErrorPopUp(BasePopup basePopup)
        {
            basePopup.SetPopupView(_errorPopupView);
            _errorPopupView.gameObject.SetActive(true);
        }
    }
}
