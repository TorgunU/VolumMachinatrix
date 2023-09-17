using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ItemViewer : MonoBehaviour
{
    [SerializeField] protected Image Image;
    [SerializeField] protected TMP_Text TextCount;

    protected virtual void Awake()
    {
        Image = GetComponent<Image>();
    }

    public void SetViewer(Sprite sprite, int itemCount)
    {
        Image.sprite = sprite;
        TextCount.text = itemCount.ToString();
    }

    public void UpdateViewer(int itemCount)
    {
        TextCount.text = itemCount.ToString();
    }

    public void ResetViewer()
    {
        Image.sprite = null;
        //Image.color = new Color(0,0,0,0);

        TextCount.text = string.Empty;
    }
}