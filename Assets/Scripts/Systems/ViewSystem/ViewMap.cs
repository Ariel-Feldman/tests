using System;
using System.Collections.Generic;

namespace Ariel.Systems
{
    public class ViewMap
    {
        public ViewMap(BaseView[] views)
        {
            _sceneViews = new();
            foreach (var view in views)
                _sceneViews.Add(view.GetType(), view);
        }
        
        public void DeActiveViews()
        {
            foreach (var keyValue in _sceneViews)
            {
                keyValue.Value.DeActiveView();
            }
        }

        public BaseView GetView(Type type)
        {
            _sceneViews.TryGetValue(type, out BaseView view);
            return view;
        }
        
        private readonly Dictionary<Type, BaseView> _sceneViews;
    }
}