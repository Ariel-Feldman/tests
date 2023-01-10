using System;
using Ariel.Models;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace Ariel.Systems
{
    public class PopupView : BaseView
    {
        [SerializeField] private TMP_Text _header;
        [SerializeField] private TMP_Text _body;
        
        [SerializeField] private TMP_Text _actionButtonText;
        [SerializeField] private Button _actionButton;
        
        [SerializeField] private TMP_Text _secondActionButtonText;
        [SerializeField] private Button _secondActionButton;

        public UnityAction OnPopupClose;
        
        public void SetTexts(string header, string body)
        {
            _header.text = header;
            _body.text = body;
        }

        public void SetActionButton(string buttonText, UnityAction onButtonClicked)
        {
            _actionButtonText.text = buttonText;
            _actionButton.onClick.AddListener(OnButtonClicked);
            
            void OnButtonClicked()
            {
                _actionButton.onClick.RemoveAllListeners();
                onButtonClicked.Invoke();
            }
        }
        
        public void SetSecondActionButton(string buttonText, UnityAction onButtonClicked)
        {
            _secondActionButtonText.text = buttonText;
            _secondActionButton.onClick.AddListener(OnSecondButtonClicked);
            
            void OnSecondButtonClicked()
            {
                _secondActionButton.onClick.RemoveAllListeners();
                onButtonClicked.Invoke();
            }
        }
    }
}
