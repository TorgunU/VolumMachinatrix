using System;

public interface ISlotItem 
{
    public void RaiseOnEmpty();
    public bool TryAddItem(Item item);
    public bool TryRemoveItem(out Item item);
    public bool IsSlotEmpty();

    public event Action OnEmpty;
}