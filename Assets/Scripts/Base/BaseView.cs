using System.Threading.Tasks;
using UnityEngine;

namespace Ariel.MVCF
{
    public abstract class BaseView : MonoBehaviour
    {
        public void DeactivateView() => gameObject.SetActive(false);

        public async Task TransitionOut()
        {
            
        }
    }
}
