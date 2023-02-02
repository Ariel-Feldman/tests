using TMPro;
using UnityEngine;

public class InputFieldSystem : MonoBehaviour
{
    [SerializeField] private TMP_InputField _inputField;
    [SerializeField] private TMP_Text _loger;
    
    private void Update()
    {
        _loger.text = GetKeyboardHeight().ToString();
        transform.position = new Vector3(0, GetKeyboardHeight(), 0);
    }
    
    
    public float GetKeyboardHeight(bool includeInput = false)
    {
#if UNITY_ANDROID
        using (var unityClass = new AndroidJavaClass("com.unity3d.player.UnityPlayer")) {
            var unityPlayer = unityClass.GetStatic<AndroidJavaObject>("currentActivity").Get<AndroidJavaObject>("mUnityPlayer");
            var view = unityPlayer.Call<AndroidJavaObject>("getView");
 
            var result = 0;
               
            if (view != null) {
                using (var rect = new AndroidJavaObject("android.graphics.Rect"))
                {
                    view.Call("getWindowVisibleDisplayFrame", rect);
                    result = Display.main.systemHeight - rect.Call<int>("height");
                }
 
                if (includeInput) {
                    var dialog = unityPlayer.Get<AndroidJavaObject>("mSoftInputDialog");
                    var decorView = dialog?.Call<AndroidJavaObject>("getWindow").Call<AndroidJavaObject>("getDecorView");
 
                    if (decorView != null) {
                        var decorHeight = decorView.Call<int>("getHeight");
                        result += decorHeight;
                    }
                }
            }
               
            return result;
        }
#else
            var height = Mathf.RoundToInt(TouchScreenKeyboard.area.height);
            return height >= Display.main.systemHeight ? 0 : height;
#endif
    }
}
