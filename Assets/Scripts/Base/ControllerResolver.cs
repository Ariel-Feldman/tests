using System;
using System.Collections.Generic;

namespace ArielBase
{
    public static class ControllerResolver
    {
        private static Dictionary<Type, BaseController> _activeControllers = new Dictionary<Type, BaseController>();
        public static T GetController<T>() where T : BaseController, new()
        {
            if (!_activeControllers.ContainsKey(typeof(T)))
                _activeControllers.Add(typeof(T), new T());

            return _activeControllers[typeof(T)] as T;
        }
    }
}