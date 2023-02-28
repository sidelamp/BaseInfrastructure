using Assets.Codebase.Core.Pool;
using Codebase.Infrastructure.Services.AssetManagement;
using UnityEngine;

namespace Codebase.Infrastructure.Services.Pool
{
    public class PoolObject<T> : PoolObjectBase<T> where T : ObjectOfPool
    {
        public PoolObject(IAssetProvider assetProvider, T prefab) : base(assetProvider, prefab)
        {
        }

        public override T GetFromPool()
        {
            return _pool.Get();
        }

        protected override T Create()
        {
            return _assetProvider.Instantiate(_prefab);
        }

        protected override void OnGet(T obj)
        {
            obj.OnDispose += OnDispose;
        }

        protected override void OnDestroy(T obj)
        {
            Debug.Log("Destroy" + obj.name);

            obj.OnDispose -= OnDispose;
            GameObject.Destroy(obj);
        }

        public override void Dispose()
        {
            Debug.Log("Dispose");
            _pool.Dispose();
        }

        protected override void OnRelease(T obj)
        {
            obj.gameObject.SetActive(false);
            obj.OnDispose -= OnDispose;
        }

        private void OnDispose(ObjectOfPool obj)
        {
            _pool.Release(obj as T);
        }
    }
}