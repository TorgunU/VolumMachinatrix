using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemViewer : MonoBehaviour
{
    [SerializeField] protected Image Image;
    [SerializeField] protected int ItemCount;

    protected virtual void Awake()
    {
        Image = GetComponent<Image>();
    }

    public void Init(Sprite sprite, int itemCount)
    {
        Image.sprite = sprite;
        ItemCount = itemCount;
    }

    public void IncreaseItemCount()
    {
        ItemCount++;
    }

    public void ClearSprite()
    {
        Image.sprite = null;
    }
}
