using System;
using System.Collections.Generic;

namespace Ariel.MVCF
{
    public static class Injector
    {
        private static Dictionary<Type, Object> _objects;

        public static T GetInstance<T>() where T : class, new()
        {
            if (!_objects.ContainsKey(typeof(T)))
                _objects.Add(typeof(T), new T());

            return _objects[typeof(T)] as T;
        }
    }
}
