using System.Collections;
using TMPro;
using UnityEngine;

public class ItemInteractableTextDisplay : MonoBehaviour
{
    [SerializeField] private TMP_Text _useText;
    [SerializeField] private TMP_Text _pickupText;
    [SerializeField] private float _distantBetweenTexts;

    private Transform _itemTranform;
    private Coroutine _displayCorutine;
    private bool _isDisplaying;

    private void Awake()
    {
        _distantBetweenTexts = 1.5f;
    }

    public void Select(Transform itemTransform)
    {
        _itemTranform = itemTransform;
        _isDisplaying = true;

        gameObject.SetActive(true);
        _displayCorutine = StartCoroutine(ChangingPosition());
    }

    public void Deselect()
    {
        _isDisplaying = false;
        StopCoroutine(_displayCorutine);
        gameObject.SetActive(false);
    }

    private IEnumerator ChangingPosition()
    {
        if (_itemTranform == null)
        {
            yield return null;
        }

        yield return new WaitWhile(() =>
        {
            _pickupText.rectTransform.position = _itemTranform.position
                + new Vector3(_distantBetweenTexts, 0, 0);
            _useText.rectTransform.position = _itemTranform.position
                + new Vector3(-_distantBetweenTexts, 0, 0);

            return _isDisplaying;
        });
    }
}
