using System.Collections.Generic;
using Ariel.Models;
using UnityEngine;

namespace Ariel.Systems
{
    public class Pool<T> : IPool<T> where T : BaseView
    {
        private T _pooledObjectView;
        private Queue<T> _poolQueue;
        private Transform _parentTransform;
        private Transform _poolRoot;

        private int PooledCount => _poolQueue.Count;

        public Pool(T pooledObjectView, Transform parentTransform, int poolCapacity)
        {
            _pooledObjectView = pooledObjectView;
            _parentTransform = parentTransform;
            _poolQueue = new Queue<T>(poolCapacity);
            
            _poolRoot = new GameObject($"[{pooledObjectView.GetType().Name}] Pool").transform;
            _poolRoot.SetParent(parentTransform, false);

            for (var i = 0; i < poolCapacity; i++)
            {
                T item = Object.Instantiate(_pooledObjectView, _poolRoot).GetComponent<T>();
                item.gameObject.SetActive(false);

                _poolQueue.Enqueue(item);
            }
        }


        public T PullFromPool()
        {
            T item;

            if (PooledCount == 0)
            {
                item = Object.Instantiate(_pooledObjectView).GetComponent<T>();
                return item;
            }

            item = _poolQueue.Dequeue();
            item.transform.SetParent(_parentTransform, false);
            item.gameObject.SetActive(true);
            return item;
        }

        public void PushToPool(T item)
        {
            item.gameObject.SetActive(false);
            item.transform.localPosition = Vector3.zero;
            item.transform.localEulerAngles = Vector3.zero;
            item.transform.SetParent(_poolRoot, false);

            _poolQueue.Enqueue(item);
        }
        
        public void Dispose()
        {
            foreach (var item in _poolQueue)
                Object.Destroy(item.gameObject);
            

            Object.Destroy(_poolRoot.gameObject);

            _pooledObjectView = null;
            _parentTransform = null;
            _poolRoot = null;
            _poolQueue = null;
        }
    }
}
