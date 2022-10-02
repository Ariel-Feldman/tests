using DG.DOTweenEditor;
using DG.Tweening;

public static class PlayTweenInEditor 
{
    public static void RunTween(Tween tween)
    {
        DOTweenEditorPreview.PrepareTweenForPreview(tween);
        DOTweenEditorPreview.Start();
    }

}
