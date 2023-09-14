using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ItemInteractableTextDisplay : MonoBehaviour
{
    [SerializeField] private TMP_Text _useText;
    [SerializeField] private TMP_Text _pickupText;
    [SerializeField] private float _distantBetweenTexts;

    private void Awake()
    {
        _distantBetweenTexts = 1.5f;
    }

    public void Select(Transform itemTransform)
    {
        ChangePosition(itemTransform);

        gameObject.SetActive(true);
    }

    public void Deselect()
    {
        gameObject.SetActive(false);
    }

    private void ChangePosition(Transform itemTransform)
    {
        _pickupText.rectTransform.position = itemTransform.position + new Vector3(_distantBetweenTexts, 0, 0);
        _useText.rectTransform.position = itemTransform.position + new Vector3(-_distantBetweenTexts, 0, 0);

        //Vector3 screenPosition = Camera.main.WorldToScreenPoint(itemTransform.position);

        //Vector3 pickupTextPosition = screenPosition + new Vector3(_distantBetweenTexts,0,0);
        //Vector3 useTextPosition = screenPosition + new Vector3(-_distantBetweenTexts, 0, 0);

        //_pickupText.rectTransform.position = Camera.main.ScreenToWorldPoint(pickupTextPosition);
        //_useText.rectTransform.position = Camera.main.ScreenToWorldPoint(useTextPosition);
    }
}
