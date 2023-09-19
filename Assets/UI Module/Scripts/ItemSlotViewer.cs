using TMPro;
using UnityEngine;

public class ItemSlotViewer : ItemViewer
{
    [SerializeField] protected TMP_Text TextCount;

    public void SetViewer(Sprite sprite, int itemCount)
    {
        SetViewer(sprite);

        TextCount.text = itemCount.ToString();
    }

    public virtual void UpdateViewer(int itemCount)
    {
        TextCount.text = itemCount.ToString();
    }

    public override void ResetViewer()
    {
        base.ResetViewer();

        TextCount.text = "0";
    }

    public override void SetViewerColors(Color currentFadeColor)
    {
        base.SetViewerColors(currentFadeColor);

        TextCount.color = currentFadeColor;
    }
}
