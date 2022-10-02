using System.Collections.Generic;
using System.Threading.Tasks;
using Ariel.Systems;
using UnityEngine;

namespace Ariel.MVCF
{
    public class StateController : BaseController
    {
        protected List<BaseView> _liveViews = new();
        
        public async Task StateTransitionOut()
        {
            List<Task> tasks = new List<Task>();
            
            foreach (var view in _liveViews)
                tasks.Add(Task.Run(view.TransitionOut));
            
            await Task.WhenAll(tasks);
            foreach (Task t in tasks)
                Debug.Log($"Task {t.Id} Status: {t.Status}");
        }
    }
}
