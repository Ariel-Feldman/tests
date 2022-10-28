using UnityEngine;

namespace Ariel.Systems
{
    public class SampleForPool
    {
        public static Pool<PoolObject> Pool;
        private GameObject objectPrefab;

        private void Init(GameObject objectPrefab)
        {
            Pool = new Pool<PoolObject>(objectPrefab);
        }
        
        
        private void SomeFunction()
        {
            // get object from pool
            PoolObject newPoolObject = Pool.PullFromPool();
        }
    }
}