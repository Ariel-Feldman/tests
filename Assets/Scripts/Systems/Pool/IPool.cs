using UnityEngine;

namespace Ariel.Systems
{
    public interface IPool<T>
    {
        public void InitPool(T pooledObjectView, Transform parentTransform, int poolCapacity);
        public T GetFromPool();
        public void PushToPool(T t);
    }
}
