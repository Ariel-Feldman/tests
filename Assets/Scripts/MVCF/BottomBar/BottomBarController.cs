namespace Ariel.MVCF
{
    public class BottomBarController : BaseController
    {
        private BottomBarView _view;

        public override void Init()
        {
            SetNotifications();
        }

        
        protected override void BindViews()
        {
            _view = BindView<BottomBarView>();
        }
        
        private void SetNotifications()
        {
        }
    }
}
