using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PoolObject<T> where T : MonoBehaviour
{
    protected T Prefab;
    protected Transform HierarhyTransform;
    protected int MinCapacity;
    protected int MaxCapacity;
    protected bool IsAutoExpand;
    protected int ExpandCopacity;
    protected List<T> PoolObjects;

    public PoolObject(T prefab, int minCapacity, int maxCapacity, Transform hierarhyTransform)
    {
        Prefab = prefab;
        HierarhyTransform = hierarhyTransform;
        MinCapacity = minCapacity;
        MaxCapacity = maxCapacity;
        IsAutoExpand = false;
        ExpandCopacity = 0;

        CreatePool();
    }

    public PoolObject(T prefab, int minCapacity, int maxCapacity, Transform hierarhyTransform,
        bool isAutoExpand, int expandCopacity)
        : this(prefab, minCapacity, maxCapacity, hierarhyTransform)
    {
        IsAutoExpand = isAutoExpand;
        ExpandCopacity = expandCopacity;

        OnValidate();
    }

    protected virtual void OnValidate()
    {
        if (IsAutoExpand)
        {
            if (ExpandCopacity > MaxCapacity)
            {
                MaxCapacity = ExpandCopacity;
            }
            else
            {
                ExpandCopacity = MaxCapacity;

                Debug.LogWarning($"Expend copacity {ExpandCopacity} can't be less max capacity" +
                    $" {MaxCapacity}");
            }
        }
    }

    public abstract T GetFreeElement();
    public abstract bool TryGetElement(out T element);
    public abstract void Release(T polledObject);

    protected abstract T CreateElement(bool isActiveByDefault = false);
    protected abstract void CreatePool();
}