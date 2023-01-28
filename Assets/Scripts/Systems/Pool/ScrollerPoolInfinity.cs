using System.Collections.Generic;
using Ariel.Systems;
using UnityEngine;
using UnityEngine.UI;

namespace Ariel.Systems
{
    [RequireComponent(typeof(ScrollRect))]
    public class ScrollerPoolInfinity : MonoBehaviour
    {
        [SerializeField] private ScrollRect _scrollRect;
        [SerializeField] private HorizontalOrVerticalLayoutGroup _layoutGroup;
        
        
        private RectOffset _padding;
        private float _elementSize;
        private int _totalElementsCount;
        private LayoutElement _spaceElement;
        
        private List<PooledObjectView> _activeElements = new ();
        
        private void Init<T>(PooledObjectView pooledObjectView)
        {
            _scrollRect = GetComponent<ScrollRect>();
            _scrollRect.onValueChanged.AddListener(OnScrollMoved);
            
            _elementSize = GetElementSize(pooledObjectView) + _layoutGroup.spacing;
            _padding = _layoutGroup.padding;
            
            // _elementsPool = new Pool<PooledElement>(Template, transform, PoolCapacity);

        }
        
        private float GetElementSize(PooledObjectView pooledObjectView)
        {
            RectTransform poolElementRectTransform = pooledObjectView.transform as RectTransform;
            return _scrollRect.vertical ? poolElementRectTransform.rect.height : poolElementRectTransform.rect.width;
        }
        
        private void OnScrollMoved(Vector2 delta)
        {
            UpdateContent();
            UpdateActiveElements();
        }

        private void UpdateContent()
        {
            AdjustContentSize(_elementSize *  _totalElementsCount);
            
            var scrollAreaSize = _scrollRect.vertical ? _scrollRect.viewport.rect.height : _scrollRect.viewport.rect.width;
            var elementsVisibleInScrollArea = Mathf.CeilToInt(scrollAreaSize / _elementSize);
            
            // var elementsCulledAbove = Mathf.Clamp(Mathf.FloorToInt(GetScrollRectNormalizedPosition() * (_totalElementsCount - elementsVisibleInScrollArea)), 0,
            //     Mathf.Clamp(_totalElementsCount - (elementsVisibleInScrollArea), 0, int.MaxValue));

            var requiredElementsInList = Mathf.Min(elementsVisibleInScrollArea + 1, _totalElementsCount);

            if (_activeElements.Count != requiredElementsInList)
            {
                // InitializeElements(requiredElementsInList, elementsCulledAbove);
            }
            
        }
        
        private void InitializeElements(int requiredElementsInList, int numElementsCulledAbove)
        {
            for (var i = 0; i < _activeElements.Count; i++)
            {
                // _elementsPool.Return(ActiveElements[i]);
            }

            _activeElements.Clear();

            for (var i = 0; i < requiredElementsInList && i + numElementsCulledAbove < _totalElementsCount; i++)
            {
                // _activeElements.Add(CreateElement(i + numElementsCulledAbove));
            }
        }
        
        private float GetScrollRectNormalizedPosition()
        {
            return Mathf.Clamp01(_scrollRect.vertical ? 1 - _scrollRect.verticalNormalizedPosition : _scrollRect.horizontalNormalizedPosition);
        }
        
        private void UpdateActiveElements()
        {
            // for (var i = 0; i < ActiveElements.Count; i++)
            // {
            //     var activeElement = ActiveElements[i];
            //     var activeData = Data[LastElementsCulledAbove + i];
            //
            //     if (!activeElement.Data.Equals(activeData))
            //     {
            //         activeElement.Data = activeData;
            //     }
            // }
        }

        private void AdjustContentSize(float size)
        {
            var currentSize = _scrollRect.content.sizeDelta;
            size -= _layoutGroup.spacing;

            if (_scrollRect.vertical)
            {
                size += _padding.top + _padding.bottom;
                currentSize.y = size;
            }
            else
            {
                size += _padding.left + _padding.right;
                currentSize.x = size;
            }

            _scrollRect.content.sizeDelta = currentSize;
        }
    }
}
