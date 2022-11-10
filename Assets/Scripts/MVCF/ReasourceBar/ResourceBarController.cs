namespace Ariel.MVCF
{
    public class ResourceBarController : BaseController
    {
        private ResourceBarView _view;
        protected override void BindViews()
        {
            _view = BindView<ResourceBarView>();
        }
    }
}
