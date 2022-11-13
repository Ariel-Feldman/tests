using System;
using System.Collections.Generic;
using Ariel.Models;

namespace Ariel.Systems
{
    public class ViewMap
    {
        public readonly Dictionary<Type, BaseView> SceneViews;
        
        public ViewMap(BaseView[] views)
        {
            SceneViews = new();
            foreach (var view in views)
                SceneViews.Add(view.GetType(), view);
        }
        
        public void SetViewsInactive()
        {
            foreach (var keyValue in SceneViews)
            {
                keyValue.Value.DeactivateView();
            }
        }

        public BaseView GetView(Type type)
        {
            SceneViews.TryGetValue(type, out BaseView view);
            return view;
        }
        
    }
}