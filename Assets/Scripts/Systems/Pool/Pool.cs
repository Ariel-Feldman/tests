using System;
using System.Collections.Generic;
using UnityEngine;

namespace Ariel.Systems
{
    public class Pool<T> : IPool<T> where T : MonoBehaviour, IPoolAble<T>
    {

        private Action<T> _onPullObject;
        private Action<T> _onPushObject;
        private Stack<T> _pooledObjects = new Stack<T>();
        
        private GameObject _poolPrefab;
        private int PooledCount => _pooledObjects.Count;

        public Pool(GameObject poolObject, int prefillCount = 0)
        {
            _poolPrefab = poolObject;
            Spawn(prefillCount);
        }

        public Pool(GameObject poolObject, Action<T> onPullObject, Action<T> onPushObject, int prefillCount = 0)
        {
            _onPullObject = onPullObject;
            _onPushObject = onPushObject;
            _poolPrefab = poolObject;
            Spawn(prefillCount);
        }

        public T PullFromPool()
        {
            T t;
            if (PooledCount > 0)
                t = _pooledObjects.Pop();
            else
                t = GameObject.Instantiate(_poolPrefab).GetComponent<T>();
            
            t.gameObject.SetActive(true);
            
            t.Init(PushToPool); // Secrete Sauce
            
            _onPullObject?.Invoke(t);
            return t;
        }

        public void PushToPool(T t)
        {
            _pooledObjects.Push(t);
            _onPushObject?.Invoke(t);
            t.gameObject.SetActive(false);
        }

        private void Spawn(int prefillCount)
        {
            for (int i = 0; i < prefillCount; i++)
            {
                PullFromPool();
            }
        }
    }
}
