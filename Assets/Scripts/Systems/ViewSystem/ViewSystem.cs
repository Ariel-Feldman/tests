using System;
using Ariel.MVCF;
using UnityEngine;

namespace Ariel.Systems
{
    public static class ViewSystem
    {
        private static ViewMap[] _viewMap;
        private static int CurrentSceneIndex => (int)SceneSystem.CurrentScene;

        public static void Init()
        {
            _viewMap = new ViewMap[Enum.GetNames(typeof(SceneType)).Length];
        }

        public static void MapSceneViews()
        {
            if (_viewMap[CurrentSceneIndex] == null)
            {
                var views = GameObject.FindObjectsOfType<BaseView>();
                _viewMap[CurrentSceneIndex] = new ViewMap(views);
            }


            _viewMap[CurrentSceneIndex].SetViewsInactive();
            
            // Debug
            // var viewsDebug = _viewMap[CurrentSceneIndex].SceneViews;
            // Debug.Log($"View Count: {viewsDebug.Count}");
            // foreach (var view in viewsDebug)
            // {
            //     Debug.Log($"view: {view}");
            // }
            // Debug
            
        }
        
        public static T GetView<T>() where T : BaseView
        {
            BaseView view;
            view = _viewMap[CurrentSceneIndex].GetView(typeof(T));
            
            if (view == null)
                Debug.LogWarning($"Failed to get view type: {typeof(T)}");

            return view as T;
        }
    }
}
