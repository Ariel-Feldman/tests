using System.Collections.Generic;
using System.Threading.Tasks;
using Ariel.Systems;

namespace Ariel.Models
{
    public abstract class BaseController
    {
        private List<BaseView> _views = new();
        private List<BaseController> _subControllers = new();

        public virtual void Init() {}
        
        public async Task TransitionOut()
        {
            await SubControllersOutRecursion();
            await ViewTransitionOut();
        }
        
        protected virtual void BindViews() { }
        
        protected T BindView<T>(bool activateViewOnBind = true) where T : BaseView
        {
            var view = SceneViewSystem.GetView<T>();
            view.gameObject.SetActive(activateViewOnBind);
            _views.Add(view);
            return view;
        }

        protected T GetController<T>() where T : BaseController, new()
        {
            var controller = Injector.GetInstance<T>();
            
            if (!_subControllers.Contains(controller))
                _subControllers.Add(controller);
            
            controller.BindViews();
            return controller;
        }
        

        private async Task SubControllersOutRecursion()
        {
            if (_subControllers.Count == 0)
                return;

            foreach (var subController in _subControllers)
                await subController.TransitionOut();
        }
        
        private async Task ViewTransitionOut()
        {
            var tasks = new List<Task>();
            foreach (var view in _views)
                tasks.Add(view.TransitionOut());

            await Task.WhenAll(tasks);
        }
    }
}
