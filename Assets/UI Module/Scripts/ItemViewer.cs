using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using TMPro;

public class ItemViewer : MonoBehaviour
{
    [SerializeField] protected Image Image;

    protected virtual void Awake()
    {
        Image = GetComponent<Image>();
    }

    public virtual void SetViewer(Sprite sprite)
    {
        Image.sprite = sprite;
    }

    public virtual void ResetViewer()
    {
        Image.sprite = null;
    }

    public virtual void SetViewerColors(Color currentFadeColor)
    {
        Image.color = currentFadeColor;
    }
}
