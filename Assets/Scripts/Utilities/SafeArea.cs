using UnityEngine;

[ExecuteAlways]
[RequireComponent(typeof(RectTransform))]
public class SafeArea : MonoBehaviour
{
    private RectTransform _rectTransform;

    private void OnRectTransformDimensionsChange()
    {
        // await MonoSystem.Instance.AwaitFrames(1);
        _rectTransform = GetComponent<RectTransform>();
        ApplySafeArea();
    }
    
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
}
