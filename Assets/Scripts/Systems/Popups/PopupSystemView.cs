using System.Collections.Generic;
using Ariel.Utilities;
using UnityEngine;

namespace Ariel.Systems
{
    public class PopupSystemView : Singleton<PopupSystemView>
    {
        [SerializeField] private PopupView _errorPopupView;
        
        private List<BasePopup> _popupQueue;

        public void CloseAllPopups()
        {
            _errorPopupView.gameObject.SetActive(false);
        }
        
        public void ShowNextPopup(BasePopup basePopup)
        {
            basePopup.SetPopupView(_errorPopupView);
            _errorPopupView.gameObject.SetActive(true);
        }
    }
}
