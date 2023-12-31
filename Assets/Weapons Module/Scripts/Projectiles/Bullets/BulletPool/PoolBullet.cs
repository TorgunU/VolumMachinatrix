using UnityEngine;

public class PoolBullet<T> : PoolObject<T> where T : Bullet
{
    public PoolBullet(T script, int minCapacity, int maxCapacity, Transform poolHierarhyTransform)
        : base(script, minCapacity, maxCapacity, poolHierarhyTransform)
    { }

    public PoolBullet(T script, int minCapacity, int maxCapacity, Transform poolHierarhyTransform,
        bool isAutoExpand, int expandCopacity)
        : base(script, minCapacity, maxCapacity, poolHierarhyTransform,
            isAutoExpand, expandCopacity)
    { }

    public void OnReleased(Bullet pooledBullet)
    {
        ReleaseObject((T)pooledBullet);
    }

    protected override void ReleaseObject(T pooledObject)
    {
        pooledObject.RevertFields();

        pooledObject.transform.position = HierarhyTransform.position;
        pooledObject.transform.rotation = HierarhyTransform.rotation;
        pooledObject.gameObject.SetActive(false); 
    }

    protected override T CreateElement(bool isActiveByDefault = false)
    {
        var createdObject = GameObject.Instantiate(Script, HierarhyTransform);
        createdObject.gameObject.SetActive(isActiveByDefault);

        createdObject.Collided += OnReleased;

        PoolObjects.Add(createdObject);

        return createdObject;
    }
}