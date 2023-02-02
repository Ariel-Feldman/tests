using UnityEngine;

[ExecuteAlways]
[RequireComponent(typeof(RectTransform))]
public class SafeArea : MonoBehaviour
{
    private RectTransform _rectTransform;
    
    private void Start()
    {
        ApplySafeArea();
    }

    [ContextMenu("Generate SafeArea")]
    private void ApplySafeArea()
    {
        _rectTransform = GetComponent<RectTransform>();
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
}
