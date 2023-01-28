using System.Collections.Generic;
using System.Threading.Tasks;
using Ariel.Systems;
using Ariel.Utilities;
using UnityEngine;

namespace Ariel.Features
{
    public abstract class BaseController
    {
        // private readonly List<T> _Tviews where T : BaseView = new();
        private readonly List<BaseView> _views = new();
        private readonly List<BaseController> _subControllers = new();

        public virtual void Init() {}
        
        public async Task TransitionOut()
        {
            await SubControllersTransitionOut();
            await ViewTransitionOut();
        }
        
        protected T GetController<T>(BaseController parentController = null) where T : BaseController, new()
        {
            var controller = Injector.GetInstance<T>();
            if (parentController != null)
                SetParentController(controller);
            
            return controller;
        }
        
        protected T GetView<T>() where T : BaseView
        {
            var view = SceneViewSystem.GetView<T>();
            if (!_views.Contains(view))
                _views.Add(view);
            
            return view;
        }
        
        protected T InstantiateView<T>(Transform parent, bool activateViewOnStart = true) where T : BaseView
        {
            var view = SceneViewSystem.GetView<T>();
            if (!_views.Contains(view))
                _views.Add(view);
            
            return view;
        }
        
        //
        private void SetParentController<T>(T controller) where T : BaseController, new()
        {
            if (!_subControllers.Contains(controller))
                _subControllers.Add(controller);
            else
                Debug.LogWarning("Parent Controller Already Attached, please check your GetController<T> calls");
            
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
