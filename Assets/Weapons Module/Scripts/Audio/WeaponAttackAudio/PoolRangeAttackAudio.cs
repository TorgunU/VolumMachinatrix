using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolRangeAttackAudio<T> : PoolObject<T> where T : RangeAttackAudio
{
    public PoolRangeAttackAudio(T script, int minCapacity, int maxCapacity,
        Transform poolHierarhyTransform)
        : base(script, minCapacity, maxCapacity, poolHierarhyTransform)
    { }

    public PoolRangeAttackAudio(T script, int minCapacity, int maxCapacity,
        Transform poolHierarhyTransform, bool isAutoExpand, int expandCopacity)
        : base(script, minCapacity, maxCapacity, poolHierarhyTransform, isAutoExpand, expandCopacity)
    { }

    private void OnFinishedPlaying(RangeAttackAudio controller)
    {
        ReleaseObject((T)controller);
    }

    protected override void ReleaseObject(T polledObject)
    {
        polledObject.gameObject.SetActive(false);
    }

    protected override T CreateElement(bool isActiveByDefault = false)
    {
        var createdObject = GameObject.Instantiate(Script, HierarhyTransform);
        createdObject.gameObject.SetActive(isActiveByDefault);

        createdObject.FinishedPlaying += OnFinishedPlaying;

        PoolObjects.Add(createdObject);
        return createdObject;
    }
}