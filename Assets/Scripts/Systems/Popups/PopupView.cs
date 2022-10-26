using Ariel.MVCF;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Ariel.Systems
{
    public class PopupView : BaseView
    {
        [SerializeField] private TMP_Text _header;
        [SerializeField] private TMP_Text _body;
        [SerializeField] private TMP_Text _actionButtonText;
        [SerializeField] private Button _actionButton;
        
        public void SetUi(PopupController popupController)
        {
            _header.text = popupController.Header;
            _body.text = popupController.Body;
            _actionButtonText.text = popupController.ButtonText;
            _actionButton.onClick.AddListener(popupController.onButtontClicked);
        }
    }
}