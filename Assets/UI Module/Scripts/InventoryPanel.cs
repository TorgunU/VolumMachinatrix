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
    
    [SerializeField] private float _displayTime = 2f;
    [SerializeField] private Image _inventoryImage;

    [SerializeField] private float _waitingActionTime = 3f;
    [SerializeField] private float _fadeInDuration = 5.0f;
    [SerializeField] private float _elapsedTime = 0.0f;

    private Coroutine _fadingCorutine;
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
        SetPanelColor(_startColor);
        SetViewersColor(_startColor);
        StartWaitingCorutine();
    }

    private void SetViewersColor(Color color)
    {
        _firstItemSlotViewer.SetViewerColors(color);
        _firstWeaponSlotViewer.SetViewerColors(color);
    }

    private void SetPanelColor(Color color)
    {
        _inventoryImage.color = color;
    }

    private void StartWaitingCorutine()
    {
        if (_waitingCorutine != null)
        {
            StopWaitingCorutine();
        }

        _waitingCorutine = StartCoroutine(WaitingActions());

        //_displayingCorutine = StartCoroutine(FadingInPanelColor());
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
        _elapsedTime = 0;

        while (_elapsedTime < _waitingActionTime)
        {
            _elapsedTime += Time.deltaTime;
            yield return null;
        }

        _elapsedTime = 0;
    }

    private IEnumerator FadingInPanelColor()
    {
        Debug.Log("Waited");

        while (_elapsedTime < _fadeInDuration)
        {
            Color fadingColor = Color.Lerp(
                _startColor, 
                _targetColor, 
                _elapsedTime / _fadeInDuration);

            SetPanelColor(fadingColor);
            SetViewersColor(fadingColor);

            _elapsedTime += Time.deltaTime;

            yield return null;
        }

        _elapsedTime = 0;

        _inventoryImage.color = _targetColor;

        PanelFadedIn?.Invoke();
    }

    public event Action PanelFadedIn;
}
