using DG.Tweening;
using UnityEngine;

namespace Ariel.Config
{
    public static class LocalConfigs
    {
        public static void SetEmbeddedConfigs()
        {
            Application.targetFrameRate = 60;
            QualitySettings.vSyncCount = 0;
            DOTween.Init();
            DOTween.defaultAutoPlay = AutoPlay.None;
        }
    }
}
