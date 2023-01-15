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
            await SubControllersTransitionOut();
            await ViewTransitionOut();
        }
        
        protected T GetController<T>(BaseController parentController = null) where T : BaseController, new()
        {
            var controller = Injector.GetInstance<T>();
            if (parentController != null && !_subControllers.Contains(controller)) 
                    _subControllers.Add(controller);
            
            return controller;
        }
        
        protected T GetView<T>() where T : BaseView
        {
            var view = SceneViewSystem.GetView<T>();
            if (!_views.Contains(view))
                _views.Add(view);
            
            return view;
        }
        
        private async Task SubControllersTransitionOut()
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
