using System;
using System.Collections.Generic;

namespace WillDriveByMyselfApp.Services
{
    public static class DependencyService
    {
        private static readonly Dictionary<string, object> _singletones = new Dictionary<string, object>();
        public static void Register<T>()
        {
            if (_singletones.ContainsKey(nameof(T)))
            {
                return;
            }
            _singletones.Add(nameof(T), Activator.CreateInstance(typeof(T)));
        }
        public static T Get<T>()
        {
            _ = _singletones.TryGetValue(nameof(T), out object result);
            return (T)result;
        }
    }
}
