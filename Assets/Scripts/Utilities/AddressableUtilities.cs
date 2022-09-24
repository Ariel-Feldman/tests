using System.Collections.Generic;
using UnityEngine.AddressableAssets;
using UnityEngine.AddressableAssets.ResourceLocators;
using UnityEngine.ResourceManagement.ResourceLocations;
using UnityEngine.ResourceManagement.ResourceProviders;

namespace Ariel.Utilities
{
    public static class AddressableUtilities
    {
        private static IResourceLocation GetLocation(object key)
        {
            foreach (IResourceLocator locator in Addressables.ResourceLocators)
            {
                IList<IResourceLocation> locations = new List<IResourceLocation>();
                bool success = locator.Locate(key, typeof(SceneInstance), out locations);

                if (success)
                {
                    return locations[0];
                }
            }

            return null;
        }
        
    }
}