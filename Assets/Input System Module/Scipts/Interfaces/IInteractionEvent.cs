using System;

public interface IInteractionEvent // like open door, interact with trigger
{
    public abstract event Action Interacted;
}
