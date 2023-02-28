using Codebase.Infrastructure.Services;
using Codebase.Infrastructure.Services.AssetManagement;
using Codebase.Infrastructure.Services.Pool;
using UnityEngine;

namespace Codebase.Core.Pool
{
    public class BulletPool : MonoBehaviour
    {
        public Bullet prefab;
        private PoolService _poolService;

        private void Start()
        {
            RegisterPool();
            GetBulletFromPool();
        }

        private void RegisterPool()
        {
            var services = AllServices.Container;
            _poolService = services.Single<PoolService>();

            var pool = new PoolObject<Bullet>(services.Single<IAssetProvider>(), prefab);
            _poolService.SetPool(pool);
        }

        private void GetBulletFromPool()
        {
            var pool = _poolService.GetPool<PoolObject<Bullet>>();
            var bullet = pool.GetFromPool();
        }
    }
}