using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using TMPro;
using DG.Tweening;

public class ItemViewer : MonoBehaviour
{
    [SerializeField] protected Image ItemImage;

    [SerializeField] private Color TargetPanelHighlightColor;

    protected Image PanelImage;

    private Color _defaultPanelColor;
    private Tween _fadeTweenItemImage;
    private Tween _fadeTweenPanelImage;
    private float _defaultItemImageAlpha;
    private float _defaultPaneImagelAlpha;

    protected virtual void Awake()
    {
        PanelImage = GetComponent<Image>();
        _defaultPanelColor = PanelImage.color;

        _defaultItemImageAlpha = 1f;
        _defaultPaneImagelAlpha = 0.5f;
    }

    public virtual void SetViewer(Sprite sprite)
    {
        ItemImage.sprite = sprite;
    }

    public virtual void ResetViewer()
    {
        ItemImage.sprite = null;
    }

    public virtual void Highlight()
    {
        PanelImage.color = TargetPanelHighlightColor;
    }

    public virtual void RemoveHighlight()
    {
        PanelImage.color = _defaultPanelColor;
    }

    public virtual void SetStartViewerAlpha()
    {
        SetAlphaPanelImage(_defaultPaneImagelAlpha, 0);
        SetAlphaItemImage(_defaultItemImageAlpha, 0);
    }

    public virtual void SetViewerAlpha(float targetAlpha, float duration)
    {
        SetAlphaPanelImage(targetAlpha, duration);
        SetAlphaItemImage(targetAlpha, duration);
    }

    protected void SetAlphaPanelImage(float targetAlpha, float duration)
    {
        StopFadeTween(_fadeTweenPanelImage);

        _fadeTweenPanelImage = PanelImage.DOFade(targetAlpha, duration)
            .SetLink(gameObject);
    }   
    
    private void SetAlphaItemImage(float targetAlpha, float duration)
    {
        StopFadeTween(_fadeTweenItemImage);

        _fadeTweenItemImage = ItemImage.DOFade(targetAlpha, duration)
            .SetLink(gameObject);
    }

    protected void StopFadeTween(Tween targetTween)
    {
        if (targetTween.IsActive() || targetTween == null)
        {
            targetTween.Kill();
        }
    }
}
