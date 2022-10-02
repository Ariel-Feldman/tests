using System.Collections.Generic;
using Ariel.Systems;

namespace Ariel.MVCF
{
    public class BaseController
    {
        private List<BaseView> _views = new();
        
        public virtual void BindViews() {}
        
        public virtual void Init() {}
        
        protected T BindView<T>(bool activateViewOnBind = true) where T : BaseView
        {
            var view = ViewSystem.GetView<T>();
            view.gameObject.SetActive(activateViewOnBind);
            _views.Add(view);
            return view;
        }
    }
}
