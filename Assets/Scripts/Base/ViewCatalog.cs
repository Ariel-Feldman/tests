using System;
using System.Collections.Generic;
using UnityEngine;

namespace Ariel.MVCF
{
    public static class ViewCatalog
    {
        private static Dictionary<Type, BaseView> Views;

        public static void LoadCatalog()
        {

            // Views = Object.FindObjectsOfType(typeof(BaseView));
        }
        
        public static T GetView<T>() where T : BaseView
        {
            BaseView view;
            Views.TryGetValue(typeof(T), out view);
            
            if (view == null)
                Debug.Log($"Fail to get view type: {typeof(T)}");

            return view as T;
        }
    }
}
