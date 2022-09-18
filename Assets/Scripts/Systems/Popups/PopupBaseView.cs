using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Ariel.Systems
{
    public class PopupBaseView : MonoBehaviour
    {
        [SerializeField] private TMP_Text _header;
        [SerializeField] private TMP_Text _body;
        [SerializeField] private TMP_Text _actionButtonText;
        [SerializeField] private Button _actionButton;
        
        public void SetBasicContext(PopupBase popupBase)
        {
            _header.text = popupBase.Header;
            _body.text = popupBase.Body;
            _actionButtonText.text = popupBase.ButtonText;
            _actionButton.onClick.AddListener(popupBase.onButtontClicked);
        }
    }
}