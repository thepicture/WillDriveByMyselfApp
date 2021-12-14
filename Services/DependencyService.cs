using System;
using System.Collections.Generic;
using System.Linq;

namespace WillDriveByMyselfApp.Services
{
    public static class DependencyService
    {
        private static readonly Dictionary<Type, object> _singletones =
            new Dictionary<Type, object>();

        public static T Get<T>() where T : class
        {
            object result = _singletones.FirstOrDefault(i => typeof(T)
            .IsAssignableFrom(i.Value.GetType())).Value;
            return result == null
                ? throw new ArgumentException("No implementation found " +
                "for " + typeof(T).FullName)
                : result as T;
        }
        public static void Register<T>() where T : class
        {
            if (_singletones.ContainsKey(typeof(T)))
            {
                throw new InvalidOperationException("Attempt to register " +
                    "already existing implementation");
            }
            _singletones.Add(typeof(T), (T)Activator.CreateInstance(typeof(T)));
        }
    }
}
