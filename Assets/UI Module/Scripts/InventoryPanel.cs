using DG.Tweening;
using System;
using System.Collections;
using System.Diagnostics.Eventing.Reader;
using System.Drawing.Text;
using UnityEngine;
using UnityEngine.UI;

public class InventoryPanel : MonoBehaviour
{
    [SerializeField] private ItemSlotViewer _firstItemSlotViewer;
    [SerializeField] private ItemViewer _firstWeaponSlotViewer;
    [SerializeField] private float _waitingActionTime = 1.5f;
    [SerializeField] private float _fadingTime = 2.0f;

    private Image _panelImage;
    private Coroutine _fadingCorutine;
    private Coroutine _waitingCorutine;
    private Tween _fadeTween;
    private ItemViewer _currentIHighlightedItemViewer;
    private ItemViewer _currentHighlightedWeaponItemViewer;

    private void Awake()
    {
        _waitingActionTime = 1.5f;
        _fadingTime = 2.0f;
        _panelImage = GetComponent<Image>();

        StartWaitingCorutine();
    }

    public void OnFirstItemSlotSetted(Sprite itemSprite, int itemsCount)
    {
        _firstItemSlotViewer.SetViewer(itemSprite, itemsCount);

        OnInventoryPressed();
    }

    public void OnFirstItemSlotUpdated(int itemsCount)
    {
        _firstItemSlotViewer.UpdateViewer(itemsCount);

        OnInventoryPressed();
    }

    public void OnFirstItemSlotResseted()
    {
        _firstItemSlotViewer.ResetViewer();

        OnInventoryPressed();
    }

    public void OnFirstWeaponSlotSetted(Sprite weaponItemSprite)
    {
        _firstWeaponSlotViewer.SetViewer(weaponItemSprite);

        OnInventoryPressed();
    }

    public void OnFirstWeaponSlotResetted()
    {
        _firstWeaponSlotViewer.ResetViewer();

        OnInventoryPressed();
    }

    public void OnInventoryPressed()
    {
        FadeOut();
        StartWaitingCorutine();
    }

    public void OnItemSlotSelected(int slotItemsNumber)
    {
        switch (slotItemsNumber)
        {
            case 1:
                HighlightItemViewer(_firstItemSlotViewer);
                break;
            default:
                return;
        }
    }

    public void OnRemovedHighlightItemViewer()
    {
        if (_currentIHighlightedItemViewer == null)
        {
            return;
        }

        _currentIHighlightedItemViewer.RemoveHighlight();
        _currentIHighlightedItemViewer = null;
    }

    public void OnWeaponlotSelected(int slotWeaponNumber)
    {
        switch (slotWeaponNumber)
        {
            case 1:
                HighlightWeaponViewer(_firstWeaponSlotViewer);
                break;
            default:
                return;
        }
    }

    public void OnRemovedHighlightWeaponViewer()
    {
        if (_currentHighlightedWeaponItemViewer == null)
        {
            return;
        }

        _currentHighlightedWeaponItemViewer.RemoveHighlight();
        _currentHighlightedWeaponItemViewer = null;
    }

    private void HighlightItemViewer(ItemViewer itemViewer)
    {
        _currentIHighlightedItemViewer = itemViewer;
        _currentIHighlightedItemViewer.Highlight();
    }

    private void HighlightWeaponViewer(ItemViewer itemViewer)
    {
        _currentHighlightedWeaponItemViewer = itemViewer;
        _currentHighlightedWeaponItemViewer.Highlight();
    }

    private void FadeOut()
    {
        FadePanel(0.8f, 0);

        _firstItemSlotViewer.SetStartViewerAlpha();
        _firstWeaponSlotViewer.SetStartViewerAlpha();
    }

    private void FadeViewers(float targetAlpha, float duration)
    {
        _firstItemSlotViewer.SetViewerAlpha(targetAlpha, duration);
        _firstWeaponSlotViewer.SetViewerAlpha(targetAlpha, duration);
    }

    private void FadePanel(float targetAlpha, float duration)
    {
        if(_fadeTween.IsActive() || _fadeTween == null)
        {
            _fadeTween.Kill();
        }

        _fadeTween = _panelImage.DOFade(targetAlpha, duration)
            .SetLink(gameObject);
    }

    private void StartWaitingCorutine()
    {
        if (_waitingCorutine != null)
        {
            StopWaitingCorutine();
        }

        _waitingCorutine = StartCoroutine(WaitingActions());
    }

    private void StopWaitingCorutine()
    {
        StopCoroutine(_waitingCorutine);

        if(_fadingCorutine != null)
        {
            StopCoroutine(_fadingCorutine);
        }
    }

    private IEnumerator WaitingActions()
    {
        yield return new WaitForSeconds(_waitingActionTime);

        _fadingCorutine = StartCoroutine(FadingInPanelColor());
    }

    private IEnumerator FadingInPanelColor()
    {
        FadePanel(0, _fadingTime);
        FadeViewers(0, _fadingTime);

        yield return new WaitForSeconds(_fadingTime);

        PanelFaded?.Invoke();

        yield return null;
    }

    public event Action PanelFaded;
}
