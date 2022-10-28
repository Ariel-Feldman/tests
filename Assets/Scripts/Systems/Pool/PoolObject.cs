using System;
using UnityEngine;

namespace Ariel.Systems
{
    public class PoolObject : MonoBehaviour, IPoolAble<PoolObject>
    {
        private Action<PoolObject> _onReturnToPoll;
        public void Init(Action<PoolObject> returnAction)
        {
            _onReturnToPoll = returnAction;
        }

        public void ReturnToPool()
        {
            _onReturnToPoll?.Invoke(this);
        }

        private void OnDisable()
        {
            ReturnToPool();
        }
    }
}