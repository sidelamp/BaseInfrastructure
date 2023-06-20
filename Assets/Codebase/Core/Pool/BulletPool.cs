using  Infrastructure.Services;
using  Infrastructure.Services.AssetManagement;
using  Infrastructure.Services.Pool;
using UnityEngine;

namespace  Core.Pool
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
            _poolService = services.Get<PoolService>();

            var pool = new PoolObject<Bullet>(services.Get<IAssetProvider>(), prefab);
            _poolService.SetPool(pool);
        }

        private void GetBulletFromPool()
        {
            var pool = _poolService.GetPool<PoolObject<Bullet>>();
            var bullet = pool.GetFromPool();
        }
    }
}