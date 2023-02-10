using System;
using System.Threading.Tasks;
using Ariel.Systems;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class InputFieldSystem : MonoBehaviour
{
    
    [SerializeField] private TMP_InputField _inputField;
    [SerializeField] private TMP_Text _loger;
    [SerializeField] private Button _submitButton;
    
    public Action<string> onTextSubmited;
        
    private float _originalHeight;
    private bool _isDestroyed;

    private void Awake()
    {
        _inputField.onSelect.AddListener(OnKeyboardOpen);
        _inputField.onDeselect.AddListener(OnKeyboardClosed);
        _inputField.onValueChanged.AddListener(OnValueChanged);
        _submitButton.onClick.AddListener(OnClickSubmit);
            
        _isDestroyed = false;
        _originalHeight = transform.position.y;

    }

    private void OnDestroy()
    {
        _inputField.onSelect.RemoveListener(OnKeyboardOpen);
        _inputField.onDeselect.RemoveListener(OnKeyboardClosed);
        _inputField.onValueChanged.RemoveListener(OnValueChanged);
        _submitButton.onClick.RemoveListener(OnClickSubmit);   
        
        _isDestroyed = true;
    }

    private void OnKeyboardOpen(string arg0)
    {
        SetPositionHeight();
    }

    private async Task SetPositionHeight()
    {
        float keyboardHeight;
        float newHeight;
        
        for (var i = 0; i < 200; i++)
        {
            if (_isDestroyed) break;
            keyboardHeight = GetKeyboardHeight();
            newHeight = keyboardHeight > _originalHeight ? keyboardHeight : _originalHeight;
            transform.position = new Vector3(transform.position.x, newHeight, 0);
            await MonoSystem.Instance.WaitFrames(1);
        }
    }


    private void OnKeyboardClosed(string arg0)
    {
        SetPositionHeight();
        _loger.text = "OnKeyboardClosed: " + arg0;
    }

    private void OnClickSubmit()
    {
        SetPositionHeight();
        _loger.text = "Submit Clicked! :" + _inputField.text;
    }

    private void OnValueChanged(string text)
    {
        onTextSubmited?.Invoke(text);
        _loger.text = text;
    }

//  //  //
    
    private float GetKeyboardHeight(bool includeInput = false)
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
