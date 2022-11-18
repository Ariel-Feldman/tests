using System.Threading.Tasks;
using Ariel.Systems.Animations;
using DG.DOTweenEditor;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(BaseTweenTransition), true )]
public class PlayTweenInEditor : Editor
{
    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();
        
        GUILayout.Space(10);
        GUILayout.BeginHorizontal();
        
        if(GUILayout.Button("Play Tween"))
        {
            var tt = (BaseTweenTransition)target;
            tt.SetEditorPreviewTween();
            RunTween(tt);
        }
        
        GUILayout.EndHorizontal();
    }

    private void RunTween(BaseTweenTransition tt)
    {
        DOTweenEditorPreview.PrepareTweenForPreview(tt.Tween, false);
        DOTweenEditorPreview.Start();
        tt.RunInEditorEnded += EditorRunEnded;
        
        void EditorRunEnded()
        {
            tt.RunInEditorEnded -= EditorRunEnded;
            DOTweenEditorPreview.Stop();
        }
    }
}
