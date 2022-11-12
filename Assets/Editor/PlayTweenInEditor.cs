using System.Threading.Tasks;
using Ariel.Systems.Animations;
using DG.DOTweenEditor;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(TweenTransition), true )]
public class PlayTweenInEditor : Editor
{
    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();
        
        GUILayout.Space(10);
        GUILayout.BeginHorizontal();
        
        if(GUILayout.Button("Play Tween"))
        {
            var tt = (TweenTransition)target;
            tt.SetEditorPreviewTween();
            RunTween(tt);
        }
        
        if(GUILayout.Button("Stop Tween"))
        {
            if (DOTweenEditorPreview.isPreviewing)
                DOTweenEditorPreview.Stop();
        }
        
        GUILayout.EndHorizontal();
    }

    private void RunTween(TweenTransition tt)
    {
        DOTweenEditorPreview.PrepareTweenForPreview(tt.Tween);
        DOTweenEditorPreview.Start();
        tt.RunInEditorEnded += EditorRunEnded;
        
        void EditorRunEnded()
        {
            tt.RunInEditorEnded -= EditorRunEnded;
            DOTweenEditorPreview.Stop();
        }
    }
}
