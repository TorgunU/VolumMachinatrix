using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using TMPro;

public class ItemViewer : MonoBehaviour
{
    [SerializeField] protected Image Image;
    [SerializeField] protected TMP_Text TextCount;

    [SerializeField] private float _duration = 5.0f; // Время, за которое должен измениться цвет.

    [SerializeField] private float _elapsedTime = 0.0f; // Прошедшее время.

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
        //Image.color = new Color(
        //    Image.color.r,
        //    Image.color.g,
        //    Image.color.b,
        //    0);
        Image.sprite = null;

        TextCount.text = "0";
    }

    public void SetViewerColors(Color currentFadeColor)
    {
        Image.color = currentFadeColor;
        TextCount.color = currentFadeColor;
    }
}
