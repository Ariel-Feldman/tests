using UnityEngine;

namespace Parana
{
    public class BasePopup : BaseView
    {
        [HideInInspector] bool AlwaysInHierarchy = false; // No need it now but keep it
        
        public void ClosePopup()
        {
            if (AlwaysInHierarchy)
            {
                gameObject.SetActive(false);
            }
            else
            {
                Destroy(gameObject);
            }
        }
    }
}
