using System;
using System.Collections.Generic;

namespace ArielBase
{
    public static class Injector
    {
        private static Dictionary<Type, BaseFeature> _activeFeatures = new();
        private static Dictionary<Type, BaseController> _activeControllers = new Dictionary<Type, BaseController>();

        public static T GetFeature<T>() where T : BaseFeature, new()
        {
            if (!_activeFeatures.ContainsKey(typeof(T)))
                _activeFeatures.Add(typeof(T), new T());

            return _activeFeatures[typeof(T)] as T;
        }
        
        public static T GetController<T>() where T : BaseController, new()
        {
            if (!_activeControllers.ContainsKey(typeof(T)))
                _activeControllers.Add(typeof(T), new T());

            return _activeControllers[typeof(T)] as T;
        }
        
    }
}