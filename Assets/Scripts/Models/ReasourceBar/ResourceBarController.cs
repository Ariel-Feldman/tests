using UnityEngine;

namespace Ariel.Models
{
    public class ResourceBarController : BaseController
    {
        private ResourceBarView _resourceBarView => GetView<ResourceBarView>();

        public override void Init()
        {
            // _resourceBarView.gameObject.SetActive(true);
        }
    }
}
