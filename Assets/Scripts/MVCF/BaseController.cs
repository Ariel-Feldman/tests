namespace Parana
{
    public class BaseController<TView>
    {
        protected TView View { get; private set; }
        
        public void BindView<T>(BaseView view) where T : class, TView
        {
            View = view as T;
        }
    }
}
