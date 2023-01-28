using System;
using System.Collections.Generic;
using Ariel.Features;

namespace Ariel.Systems
{
    public class SceneViewMap
    {
        private readonly Dictionary<Type, BaseView> _sceneViews;
        
        public SceneViewMap(BaseView[] views)
        {
            _sceneViews = new();
            foreach (var view in views)
                _sceneViews.Add(view.GetType(), view);
        }
        
        public void SetViewsInactive()
        {
            foreach (var keyValue in _sceneViews)
            {
                keyValue.Value.DeactivateView();
            }
        }

        public BaseView GetView(Type type)
        {
            _sceneViews.TryGetValue(type, out BaseView view);
            return view;
        }
        
    }
}