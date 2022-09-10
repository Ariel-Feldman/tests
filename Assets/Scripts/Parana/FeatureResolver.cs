using System;
using System.Collections.Generic;

namespace Parana
{
    public static class FeatureResolver
    {
        private static Dictionary<Type, BaseFeature> _activeFeatures = new Dictionary<Type, BaseFeature>();
        public static T GetFeature<T>() where T : BaseFeature, new()
        {
            if (!_activeFeatures.ContainsKey(typeof(T)))
                _activeFeatures.Add(typeof(T), new T());

            return _activeFeatures[typeof(T)] as T;
        }
    }
}
