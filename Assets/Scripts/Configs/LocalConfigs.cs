using UnityEngine;

public static class LocalConfigs 
{

    public static void SetQualitySettings()
    {

        Application.targetFrameRate = 60;
        QualitySettings.vSyncCount = 0;
    }
}
