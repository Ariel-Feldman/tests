using UnityEngine;

[ExecuteInEditMode]
[RequireComponent(typeof(RectTransform))]
public class SafeArea : MonoBehaviour
{
    [SerializeField] private RectTransform _rectTransform;
    // Start is called before the first frame update
    private void ApplySafeArea()
    {
        if (_rectTransform == null) return;
        
        var safeArea = Screen.safeArea;
 
        var anchorMin = safeArea.position;
        var anchorMax = anchorMin + safeArea.size;
        
        anchorMin.x /= Screen.width;
        anchorMin.y /= Screen.height;
        anchorMax.x /= Screen.width;
        anchorMax.y /= Screen.height;
 
        _rectTransform.anchorMin = anchorMin;
        _rectTransform.anchorMax = anchorMax;
    }

    private void OnRectTransformDimensionsChange()
    {
        ApplySafeArea();
    }

}
