using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;
using Debug = UnityEngine.Debug;

namespace Ariel.MVCF
{
    public class BaseController
    {
        private List<BaseView> _activeViews;
        
        public async Task TransitionOut()
        {
            List<Task> tasks = new List<Task>();
            foreach (var view in _activeViews)
            {
                tasks.Add(Task.Run(view.TransitionOut));
            }
            
            await Task.WhenAll(tasks);
            foreach (Task t in tasks)
                Debug.Log($"Task {t.Id} Status: {t.Status}");
        }
    }
}