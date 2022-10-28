using System;

namespace Ariel.Systems
{
    public interface IPoolAble<T>
    {
        public void Init(Action<T> returnAction);
        public void ReturnToPool();
    }
}
