using UnityEngine;

namespace Ariel.MVCF
{
    public static class ViewResolver
    {
        public static T GetView<T>() where T : class
        {
           Debug.Log($" Requesting type of {typeof(T)} View");

           // var view = new BaseView() as T;
           return null;
        }
    }
}