using UnityEngine.Events;

namespace Ariel.Systems
{
    public class PopupBase
    {
        public string Header;
        public string Body;
        
        public string ButtonText;
        public UnityAction onButtontClicked;
        
        public string SecondButtonText;
        public UnityAction onSecondButtontClicked;


        private PopupBaseView _popupBaseView;
        
        public void SetActionButton(string buttonText, UnityAction onRestartClicked)
        {
            ButtonText = buttonText;
            onButtontClicked = onRestartClicked;
        }
        
        public void SetSecondActionButton(string buttonText, UnityAction onRestartClicked)
        {
            SecondButtonText = buttonText;
            onSecondButtontClicked = onRestartClicked;
        }
    }
}