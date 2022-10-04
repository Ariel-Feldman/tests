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

        if(GUILayout.Button("Play Tween"))
        {
            var transition = (TweenTransition)target;
            transition.SetTween();
            RunTween(transition);
        }

    }

    private async void RunTween(TweenTransition tweenTransition)
    {
        DOTweenEditorPreview.PrepareTweenForPreview(tweenTransition.Tween);
        DOTweenEditorPreview.Start();
        await Task.Delay((int)tweenTransition.Duration * 1000);
        DOTweenEditorPreview.Stop(true);
    }
}
