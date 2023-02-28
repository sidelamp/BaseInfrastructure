using Assets.Codebase.Core.Pool;
using Codebase.Infrastructure.Services.AssetManagement;
using UnityEngine.Pool;

namespace Codebase.Infrastructure.Services.Pool
{
    public abstract class PoolBase
    {
        public abstract void Dispose();
    }

    public abstract class PoolObjectBase<T> : PoolBase where T : ObjectOfPool
    {
        protected readonly ObjectPool<T> _pool;
        protected readonly IAssetProvider _assetProvider;
        protected readonly T _prefab;

        public PoolObjectBase(IAssetProvider assetProvider, T prefab)
        {
            _assetProvider = assetProvider;
            _prefab = prefab;
            _pool = new(Create, OnGet, OnRelease, OnDestroy);
        }

        public abstract T GetFromPool();

        protected abstract T Create();

        protected abstract void OnGet(T obj);

        protected abstract void OnRelease(T obj);

        protected abstract void OnDestroy(T obj);
    }
}