using System.Threading.Tasks;
using UnityEngine;

namespace Ariel.Systems
{
    public abstract class BaseView : MonoBehaviour
    {
        public void DeactivateView() => gameObject.SetActive(false);

        public async Task TransitionOut()
        {
            
        }
    }
}
