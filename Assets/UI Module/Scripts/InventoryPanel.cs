using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class InventoryPanel : MonoBehaviour
{
    [SerializeField] private ItemViewer _firstItemViewer;
    // weapon slot
    // other slots items
    [SerializeField] private float _displayTime = 2f;
    [SerializeField] private Image _inventoryColor;

    [SerializeField] private float _duration = 5.0f; // Время, за которое должен измениться цвет.

    [SerializeField] private float _elapsedTime = 0.0f; // Прошедшее время.

    private Coroutine _displayingCorutine;
    private Color _startColor; // Начальный цвет.
    private Color _targetColor; // Целевой цвет, который вы хотите достичь.

    private void Awake()
    {
        _startColor = _inventoryColor.color;
        _targetColor = new Color(
            _inventoryColor.color.r,
            _inventoryColor.color.g,
            _inventoryColor.color.b,
            0);
    }

    public void OnFirstSlotSetted(Sprite itemSprite, int itemsCount)
    {
        _firstItemViewer.SetViewer(itemSprite, itemsCount);

        _displayingCorutine = StartCoroutine(FadeInPanel());
    }

    public void OnFirstSlotUpdated(int itemsCount)
    {
        _firstItemViewer.UpdateViewer(itemsCount);

        _displayingCorutine = StartCoroutine(FadeInPanel());
    }

    public void OnFirstSlotResseted()
    {
        _firstItemViewer.ResetViewer();

        _displayingCorutine = StartCoroutine(FadeInPanel());
    }

    private IEnumerator FadeInPanel()
    {
        while (_elapsedTime < _duration)
        {
            _inventoryColor.color = Color.Lerp(
                _startColor, 
                _targetColor, 
                _elapsedTime / _duration);

            _elapsedTime += Time.deltaTime;

            yield return null;
        }

        _elapsedTime = 0;

        _inventoryColor.color = _targetColor;

        _firstItemViewer.gameObject.SetActive(false);
    }

}
