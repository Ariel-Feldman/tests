using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Ariel.Utilities
{
    public class ViewSwiper : MonoBehaviour, IDragHandler, IEndDragHandler
    {
        [SerializeField] private int totalPages;
        [SerializeField] private float percentThreshold = 0.2f;
        [SerializeField] private float easing = 0.5f;
        [SerializeField] private float _slideSpeed = 1;
        
        private int currentPage = 1;
        private Vector3 panelLocation;

        private void Start()
        {
            panelLocation = transform.position;
        }

        public void OnDrag(PointerEventData data)
        {
            var difference = data.pressPosition.x - data.position.x;
            transform.position = panelLocation - new Vector3(difference, 0, 0);
        }

        public void OnEndDrag(PointerEventData data)
        {
            var percentage = (data.pressPosition.x - data.position.x) / Screen.width;
            if (Mathf.Abs(percentage) >= percentThreshold)
            {
                var newLocation = panelLocation;
                if (percentage > 0 && currentPage < totalPages)
                {
                    currentPage++;
                    newLocation += new Vector3(-Screen.width, 0, 0);
                }
                else if (percentage < 0 && currentPage > 1)
                {
                    currentPage--;
                    newLocation += new Vector3(Screen.width, 0, 0);
                }

                StartCoroutine(SmoothMove(transform.position, newLocation, easing));
                panelLocation = newLocation;
            }
            else
            {
                StartCoroutine(SmoothMove(transform.position, panelLocation, easing));
            }
        }

        IEnumerator SmoothMove(Vector3 startPosition, Vector3 endPosition, float seconds)
        {
            var t = 0f;
            while (t <= _slideSpeed)
            {
                t += Time.deltaTime / seconds;
                transform.position = Vector3.Lerp(startPosition, endPosition, Mathf.SmoothStep(0f, 1f, t));
                yield return null;
            }
        }
    }
}
