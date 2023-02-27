using Codebase.Infrastructure.Services.AssetManagement;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

namespace Codebase.Infrastructure.Services.Pool
{
    public interface IPool
    { }

    public abstract class PoolBase<T> : IPool where T : MonoBehaviour
    {
        protected readonly ObjectPool<T> _pool;
        protected readonly IAssetProvider _assetProvider;
        protected readonly T _prefab;

        public PoolBase(IAssetProvider assetProvider, T prefab)
        {
            _assetProvider = assetProvider;
            _prefab = prefab;
            _pool = new(Create, Get, Release);
        }

        public abstract T GetFromPool();

        protected abstract T Create();

        protected abstract void Get(T obj);

        protected abstract void Release(T obj);
    }

    public class PoolService
    {
        private readonly Dictionary<Type, PoolBase<MonoBehaviour>> _pools = new();

        public void SetPool<T>(PoolBase<MonoBehaviour> pool) where T : MonoBehaviour
        {
            _pools.Add(typeof(T), pool);
        }

        public T GetPool<T>() where T : MonoBehaviour
        {
            if (!_pools.ContainsKey(typeof(T)))
                return null;

            return _pools[typeof(T)] as T;
        }
    }
}