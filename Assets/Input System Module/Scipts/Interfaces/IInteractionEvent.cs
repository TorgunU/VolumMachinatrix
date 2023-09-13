using System;

public interface IInteractionEvent
{
    public abstract event Action Interacted;
}
