using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Pool;

public class PoolBullet<T> : PoolObject<T> where T : Bullet
{
    public PoolBullet(T prefab, Transform hierarchyPosition, int minCapacity, int maxCapacity)
        : base(prefab, hierarchyPosition, minCapacity, maxCapacity)
    { }

    public PoolBullet(T prefab, Transform hierarchyPosition, int minCapacity, int maxCapacity,
        bool isAutoExpand, int expandCopacity)
        : base(prefab, hierarchyPosition, minCapacity, maxCapacity,
            isAutoExpand, expandCopacity)
    { }

    public override T GetFreeElement()
    {
        if (TryGetElement(out var element))
        {
            return element;
        }

        if (IsAutoExpand)
        {
            return CreateElement(true);
        }

        Debug.LogWarning("Pool Bullet is over!");

        return null;
    }

    public override bool TryGetElement(out T element)
    {
        foreach (var pooledObject in PoolObjects)
        {
            if(pooledObject.gameObject.activeInHierarchy == false)
            {
                element = pooledObject;
                pooledObject.gameObject.SetActive(true);

                return true;
            }
        }

        if(IsAutoExpand)
        {
            element = CreateElement(true);
            return true;
        }

        element = null;
        return false;
    }

    public override void Release(T polledObject)
    {
        polledObject.RevertConfig(RevertTransform);
        polledObject.gameObject.SetActive(false); 
    }

    protected override T CreateElement(bool isActiveByDefault = false)
    {
        var createdObject = GameObject.Instantiate(Prefab, RevertTransform);
        createdObject.gameObject.SetActive(isActiveByDefault);

        PoolObjects.Add(createdObject);
        createdObject.Collided += Release;

        return createdObject;
    }

    protected override void CreatePool()
    {
        PoolObjects = new List<T>(MinCapacity);

        for (int i = 0; i < MinCapacity; i++)
        {
            CreateElement(false);
        }
    }

    public void Release(Bullet pooledBullet)
    {
        pooledBullet.RevertConfig(RevertTransform);
        pooledBullet.gameObject.SetActive(false);
    }
}