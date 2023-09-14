using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ItemViewer : MonoBehaviour
{
    [SerializeField] protected Image Image;
    [SerializeField] protected TMP_Text TextItemsCount;

    protected virtual void Awake()
    {
        Image = GetComponent<Image>();
    }

    public void UpdateViewer(Sprite sprite, int itemCount)
    {
        Image.sprite = sprite;
        TextItemsCount.text = itemCount.ToString();
    }

    public void ClearSprite()
    {
        Image.sprite = null;
    }
}
