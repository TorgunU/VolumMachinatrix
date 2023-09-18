using System;
using System.Collections;
using System.Diagnostics.Eventing.Reader;
using System.Drawing.Text;
using UnityEngine;
using UnityEngine.UI;

public class InventoryPanel : MonoBehaviour
{
    [SerializeField] private ItemViewer _firstItemViewer;
    // weapon slot
    // other slots items
    [SerializeField] private float _displayTime = 2f;
    [SerializeField] private Image _inventoryImage;

    [SerializeField] private float _waitingActionTime = 3f;
    [SerializeField] private float _fadeInDuration = 5.0f;
    [SerializeField] private float _elapsedTime = 0.0f;

    private Coroutine _displayingCorutine;
    private Color _startColor;
    private Color _targetColor;
    private Coroutine _waitingCorutine;

    private void Awake()
    {
        _startColor = _inventoryImage.color;
        _targetColor = new Color(
            _inventoryImage.color.r,
            _inventoryImage.color.g,
            _inventoryImage.color.b,
            0);

        StartFadingCorutine();
    }

    public void OnFirstSlotSetted(Sprite itemSprite, int itemsCount)
    {
        _firstItemViewer.SetViewer(itemSprite, itemsCount);

        OnInventoryPressed();
    }

    public void OnFirstSlotUpdated(int itemsCount)
    {
        _firstItemViewer.UpdateViewer(itemsCount);

        OnInventoryPressed();
    }

    public void OnFirstSlotResseted()
    {
        _firstItemViewer.ResetViewer();

        OnInventoryPressed();
    }

    public void OnInventoryPressed()
    {
        SetStartColor();
        StartFadingCorutine();
    }

    private void SetStartColor()
    {
        _inventoryImage.color = _startColor;

        _firstItemViewer.SetViewerColors(_startColor);
    }

    private void StartFadingCorutine()
    {
        if (_displayingCorutine != null)
        {
            StopCoroutine(_displayingCorutine);
        }

        _displayingCorutine = StartCoroutine(FadingInPanelColor());
    }

    private IEnumerator FadingInPanelColor()
    {
        yield return StartCoroutine(WaitingActions());

        Debug.Log("Waited");

        while (_elapsedTime < _fadeInDuration)
        {
            _inventoryImage.color = Color.Lerp(
                _startColor, 
                _targetColor, 
                _elapsedTime / _fadeInDuration);

            _firstItemViewer.SetViewerColors(_inventoryImage.color);

            _elapsedTime += Time.deltaTime;

            yield return null;
        }

        _elapsedTime = 0;

        _inventoryImage.color = _targetColor;

        PanelFadedIn?.Invoke();
    }

    private IEnumerator WaitingActions()
    {
        while (_elapsedTime < _waitingActionTime)
        {
            _elapsedTime += Time.deltaTime;
            yield return null;
        }

        _elapsedTime = 0;
    }

    public event Action PanelFadedIn;
}
