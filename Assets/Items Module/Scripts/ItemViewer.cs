using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemViewer : MonoBehaviour
{
    protected Image Image;

    protected virtual void Awake()
    {
        Image = GetComponent<Image>();
    }

    public void InjectSprite(Sprite sprite)
    {
        Image.sprite = sprite;
    }

    public void ClearSprite()
    {
        Image.sprite = null;
    }
}
