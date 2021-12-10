using System;
using System.Collections.Generic;

namespace WillDriveByMyselfApp.Services
{
    public static class DependencyService
    {
        private static readonly Dictionary<string, object> _singletones = new Dictionary<string, object>();
        public static void Register<T>() where T : class
        {
            if (_singletones.ContainsKey(typeof(T).FullName))
            {
                return;
            }
            _singletones.Add(typeof(T).FullName, Activator.CreateInstance(typeof(T)));
        }
        public static T Get<T>() where T : class
        {
            _ = _singletones.TryGetValue(typeof(T).FullName, out object result);
            return (T)result;
        }
    }
}
