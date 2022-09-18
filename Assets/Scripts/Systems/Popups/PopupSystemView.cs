using System.Collections.Generic;
using UnityEngine;
using Ariel.Utilities;

namespace Ariel.Systems
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
