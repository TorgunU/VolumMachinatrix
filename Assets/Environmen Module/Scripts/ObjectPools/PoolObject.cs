using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PoolObject<T> where T : MonoBehaviour
{
    protected T Script;
    protected Transform HierarhyTransform;
    protected int MinCapacity;
    protected int MaxCapacity;
    protected bool IsAutoExpand;
    protected int ExpandCopacity;
    private List<T> poolObjects;

    public PoolObject(T script, int minCapacity, int maxCapacity, Transform hierarhyTransform)
    {
        Script = script;
        HierarhyTransform = hierarhyTransform;
        MinCapacity = minCapacity;
        MaxCapacity = maxCapacity;
        IsAutoExpand = false;
        ExpandCopacity = 0;

        CreatePool();
    }

    public PoolObject(T script, int minCapacity, int maxCapacity, Transform hierarhyTransform,
        bool isAutoExpand, int expandCopacity)
        : this(script, minCapacity, maxCapacity, hierarhyTransform)
    {
        IsAutoExpand = isAutoExpand;
        ExpandCopacity = expandCopacity;

        OnValidate();
    }

    public T GetFreeElement()
    {
        if (TryGetElement(out var element))
        {
            return element;
        }

        if (IsAutoExpand)
        {
            return CreateElement(true);
        }

        Debug.LogWarning($"Pool {typeof(T)} is over!");

        return null;
    }

    public bool TryGetElement(out T element)
    {
        foreach (var pooledObject in poolObjects)
        {
            if (pooledObject.gameObject.activeInHierarchy == false)
            {
                element = pooledObject;
                pooledObject.gameObject.SetActive(true);

                return true;
            }
        }

        if (IsAutoExpand)
        {
            element = CreateElement(true);
            return true;
        }

        element = null;
        return false;
    }

    public void Release(T polledObject)
    {
        ReleaseObject(polledObject);
    }

    protected virtual void CreatePool()
    {
        poolObjects = new List<T>(MinCapacity);

        for (int i = 0; i < MinCapacity; i++)
        {
            CreateElement(false);
        }
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

    protected abstract void ReleaseObject(T pooledObject);
    protected abstract T CreateElement(bool isActiveByDefault = false);

    public List<T> PoolObjects { get => poolObjects; }
}