using UnityEngine;

namespace Ariel.Config
{
    public static class LocalConfigs
    {
        public static void SetEmbeddedConfigs()
        {
            SetQualitySettings();
        }


        private static void SetQualitySettings()
        {

            Application.targetFrameRate = 60;
            QualitySettings.vSyncCount = 0;
        }
    }
}
