using System;
using UnityEngine;

namespace Ariel.Systems
{
    public static class ViewSystem
    {
        private static ViewMap[] _viewMap;
        private static int _currentSceneIndex => (int)SceneSystem.CurrentScene;

        public static void Init()
        {
            _viewMap = new ViewMap[Enum.GetNames(typeof(SceneType)).Length];
        }

        public static void ResolveSceneViews()
        {
            if (_viewMap[_currentSceneIndex] != null)
            {
                _viewMap[_currentSceneIndex].DeActiveViews();
                return;
            }

            var views = GameObject.FindObjectsOfType<BaseView>();
            // Debug
            Debug.Log($"View Count: {views.Length}");
            foreach (var view in views)
            {
                Debug.Log($"view: {view}");
            }
            // Debug
            _viewMap[_currentSceneIndex] = new ViewMap(views);
            _viewMap[_currentSceneIndex].DeActiveViews();
        }
        
        public static T GetView<T>() where T : BaseView
        {
            BaseView view;
            view = _viewMap[_currentSceneIndex].GetView(typeof(T));
            
            if (view == null)
                Debug.Log($"Fail to get view type: {typeof(T)}");

            return view as T;
        }
    }
}
