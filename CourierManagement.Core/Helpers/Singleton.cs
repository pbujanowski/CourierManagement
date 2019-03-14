using System;
using System.Collections.Concurrent;

namespace CourierManagement.Core.Helpers
{
    public static class Singleton<T>
        where T : new()
    {
        private static readonly ConcurrentDictionary<Type, T> instances = new ConcurrentDictionary<Type, T>();

        public static T Instance
        {
            get
            {
                return instances.GetOrAdd(typeof(T), (_) => new T());
            }
        }
    }
}