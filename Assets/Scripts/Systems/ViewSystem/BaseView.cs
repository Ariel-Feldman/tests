using System.Threading.Tasks;
using UnityEngine;

namespace Ariel.Systems
{
    public class BaseView : MonoBehaviour
    {
        public void DeActiveView() => gameObject.SetActive(false);
        public async Task TransitionOut()
        {
            await Task.Delay(333);
        }
    }
}
