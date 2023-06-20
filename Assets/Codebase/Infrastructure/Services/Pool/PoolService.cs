using System;
using System.Collections.Generic;

namespace  Infrastructure.Services.Pool
{
    public class PoolService : IService
    {
        private readonly Dictionary<Type, PoolBase> _pools = new();

        public void SetPool<T>(T pool) where T : PoolBase
        {
            _pools.Add(typeof(T), pool);
        }

        public T GetPool<T>() where T : PoolBase
        {
            if (!_pools.ContainsKey(typeof(T)))
                return null;

            return _pools[typeof(T)] as T;
        }

        public void Clear()
        {
            foreach (var item in _pools)
                item.Value.Dispose();

            _pools.Clear();
        }
    }
}