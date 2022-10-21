using Ariel.MVCF;
using UnityEngine.Events;

namespace Ariel.Systems
{
    public class PopupController : BaseController
    {
        public string Header;
        public string Body;
        
        public string ButtonText;
        public UnityAction onButtontClicked;
        
        public string SecondButtonText;
        public UnityAction onSecondButtontClicked;
        
        private PopupView _popupView;
        
        protected override void BindViews()
        {
            _popupView = BindView<PopupView>();
        }
        
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

        public override void Init() {}
    }
}