using System;
using Ariel.Features;
using UnityEngine;

namespace Ariel.Systems
{
    public static class SceneViewSystem
    {
        private static SceneViewMap[] _viewMap;
        private static int CurrentSceneIndex => (int)SceneSystem.CurrentScene;

        public static void Init()
        {
            _viewMap = new SceneViewMap[Enum.GetNames(typeof(SceneType)).Length];
        }

        public static void MapSceneViews()
        {
            if (_viewMap[CurrentSceneIndex] == null)
            {
                var views = GameObject.FindObjectsOfType<BaseView>();
                _viewMap[CurrentSceneIndex] = new SceneViewMap(views);
            }
        }
        
        public static T GetView<T>() where T : BaseView
        {
            BaseView view = _viewMap[CurrentSceneIndex].GetView(typeof(T));
            if (view == null)
                Debug.LogWarning($"Failed to get view type: {typeof(T)}");

            return view as T;
        }
    }
}
