using UnityEngine.Events;

namespace Ariel.Systems
{
    public class BasePopup
    {
        public string Header;
        public string Body;
        
        private string _buttonText;
        private UnityAction _onButtonClicked;
        
        private string _secondButtonText;
        private UnityAction _onSecondButtonClicked;
        
        public void ActionButton(string buttonText, UnityAction onRestartClicked)
        {
            _buttonText = buttonText;
            _onButtonClicked = onRestartClicked;
        }
        
        public void SecondActionButton(string buttonText, UnityAction onRestartClicked)
        {
            _secondButtonText = buttonText;
            _onSecondButtonClicked = onRestartClicked;
        }
        
        public void SetPopupView(PopupView popupView)
        {
            popupView.SetTexts(Header, Body);
            popupView.SetActionButton(_buttonText, _onButtonClicked);
            
            if(!string.IsNullOrEmpty(_secondButtonText) && _onSecondButtonClicked != null)
                popupView.SetSecondActionButton(_secondButtonText, _onSecondButtonClicked);
        }
    }
}