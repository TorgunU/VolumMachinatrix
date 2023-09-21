using DG.Tweening;
using TMPro;
using UnityEngine;

public class ItemSlotViewer : ItemViewer
{
    [SerializeField] protected TMP_Text TextCount;

    private Tween _textCountFadeTween;
    private float _startTextCountFade = 1f;

    public void SetViewer(Sprite sprite, int itemCount)
    {
        SetViewer(sprite);

        TextCount.text = itemCount.ToString();
    }

    public virtual void UpdateViewer(int itemCount)
    {
        TextCount.text = itemCount.ToString();
    }

    public override void ResetViewer()
    {
        base.ResetViewer();

        TextCount.text = "0";
    }

    public override void SetStartViewerAlpha()
    {
        base.SetStartViewerAlpha();

        StopFadeTween(_textCountFadeTween);
        _textCountFadeTween = TextCount.DOFade(_startTextCountFade, 0)
            .SetLink(gameObject);
    }

    public override void SetViewerAlpha(float targetAlpha, float duration)
    {
        base.SetViewerAlpha(targetAlpha, duration);

        StopFadeTween(_textCountFadeTween);
        _textCountFadeTween = TextCount.DOFade(targetAlpha, duration)
            .SetLink(gameObject);
    }
}
