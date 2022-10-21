using System.Collections.Generic;
using System.Threading.Tasks;
using Ariel.Systems;

namespace Ariel.MVCF
{
    public abstract class BaseController
    {
        private List<BaseView> _views = new();
        private List<BaseController> _subControllers = new();

        public virtual void Init() { }
        
        public async Task TransitionOutView()
        {
            await SubControllersOutRecursion();
            await OwnViewTransitionOut();
        }
        
        protected virtual void BindViews() { }
        
        protected T BindView<T>(bool activateViewOnBind = true) where T : BaseView
        {
            var view = ViewSystem.GetView<T>();
            view.gameObject.SetActive(activateViewOnBind);
            _views.Add(view);
            return view;
        }

        protected T GetController<T>() where T : BaseController, new()
        {
            var controller = Injector.GetInstance<T>();
            _subControllers.Add(controller);
            
            if (_views.Count == 0) 
                BindViews();
            
            return controller;
        }
        

        private async Task SubControllersOutRecursion()
        {
            if (_subControllers.Count == 0)
                return;

            foreach (var subController in _subControllers)
                await subController.TransitionOutView();
        }
        
        private async Task OwnViewTransitionOut()
        {
            var tasks = new List<Task>();
            foreach (var view in _views)
                tasks.Add(view.TransitionOut());

            await Task.WhenAll(tasks);
        }
    }
}
