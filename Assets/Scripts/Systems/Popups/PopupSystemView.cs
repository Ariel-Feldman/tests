using System.Collections.Generic;
using UnityEngine;
using Utilities;

namespace ArielSystems
{
    public class PopupSystemView : Singleton<PopupSystemView>
    {
        [SerializeField] private PopupBaseView _popupBaseView;

        private List<PopupBase> _livePopups;

        public void AddPopupToQueue(PopupBase popupBase)
        {
            _popupBaseView.SetBasicContext(popupBase);
            var instantiatedPopup = Instantiate(_popupBaseView, transform);
        }
    }
}
