using System;
using UnityEngine;

public enum CollideType
{
    TriggerEnter,
    TriggerStay,
    TriggerExit,
    CollisionEnter,
    CollisionStay,
    CollisionExit,
}

public class ColliderFilter
{
    public string Name;
    public string Tag;
    public int Layer;
    public string LayerName;
    public CollideType Type;
    private LayerMask LayerMask => Layer != 0 ? Layer : LayerMask.NameToLayer(LayerName);
    public Action<Collider> ColliderCallback;
    public Action<Collision> CollisionCallback;
    public Func<Collider, bool> Condition;

    public readonly Action<Collider> TryInvokeCollider;
    public readonly Action<Collision> TryInvokeCollision;


    public ColliderFilter()
    {
        TryInvokeCollider = Invoke;
        TryInvokeCollision = Invoke;
    }

    private void Invoke(Collider collider)
    {
        if (!CheckTag(collider)) return;
        if (!CheckLayer(collider)) return;
        ColliderCallback?.Invoke(collider);
    }

    private void Invoke(Collision collision)
    {
        var collider = collision.collider;
        if (!CheckTag(collider)) return;
        if (!CheckLayer(collider)) return;
        if (!CheckCondition(collider)) return;
        CollisionCallback?.Invoke(collision);
    }

    private bool CheckTag(Component collider)
    {
        return string.IsNullOrWhiteSpace(Tag) || collider.CompareTag(Tag);
    }

    private bool CheckLayer(Component collider)
    {
        return collider.gameObject.layer == LayerMask;
    }

    private bool CheckCondition(Collider collider)
    {
        return Condition == null ? true : Condition.Invoke(collider);
    }

    public void Clear()
    {
        Name = default;
        Tag = default;
        Layer = default;
        LayerName = default;
        Type = default;
        ColliderCallback = null;
        CollisionCallback = null;
        Condition = null;
    }
}