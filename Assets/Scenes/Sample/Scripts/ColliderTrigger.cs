using System;
using System.Collections.Generic;
using UnityEngine;

public class ColliderTrigger : MonoBehaviour
{
    private readonly Dictionary<string, ColliderFilter> m_FilterMap = new Dictionary<string, ColliderFilter>();
    private event Action<Collider> m_OnTriggerEnter;
    private event Action<Collider> m_OnTriggerStay;
    private event Action<Collider> m_OnTriggerExit;
    private event Action<Collision> m_OnCollisionEnter;
    private event Action<Collision> m_OnCollisionStay;
    private event Action<Collision> m_OnCollisionExit;

    public void AddFilter(ColliderFilter filter)
    {
        if (!m_FilterMap.ContainsKey(filter.Name))
        {
            m_FilterMap.Add(filter.Name, filter);
            switch (filter.Type)
            {
                case CollideType.TriggerEnter:
                    m_OnTriggerEnter += filter.TryInvokeCollider;
                    break;
                case CollideType.TriggerStay:
                    m_OnTriggerStay += filter.TryInvokeCollider;
                    break;
                case CollideType.TriggerExit:
                    m_OnTriggerExit += filter.TryInvokeCollider;
                    break;
                case CollideType.CollisionEnter:
                    m_OnCollisionEnter += filter.TryInvokeCollision;
                    break;
                case CollideType.CollisionStay:
                    m_OnCollisionStay += filter.TryInvokeCollision;
                    break;
                case CollideType.CollisionExit:
                    m_OnCollisionExit += filter.TryInvokeCollision;
                    break;
            }
        }
    }

    #region Unity Function

    private void OnTriggerEnter(Collider other)
    {
        m_OnTriggerEnter?.Invoke(other);
    }

    private void OnTriggerStay(Collider other)
    {
        m_OnTriggerStay?.Invoke(other);
    }

    private void OnTriggerExit(Collider other)
    {
        m_OnTriggerExit?.Invoke(other);
    }

    private void OnCollisionEnter(Collision collision)
    {
        m_OnCollisionEnter?.Invoke(collision);
    }

    private void OnCollisionStay(Collision collision)
    {
        m_OnCollisionStay?.Invoke(collision);
    }

    private void OnCollisionExit(Collision other)
    {
        m_OnCollisionExit?.Invoke(other);
    }

    public void ClearFilter()
    {
        m_FilterMap.Clear();
        m_OnTriggerEnter = null;
        m_OnTriggerStay = null;
        m_OnTriggerExit = null;
        m_OnCollisionEnter = null;
        m_OnCollisionStay = null;
        m_OnCollisionExit = null;
    }
    #endregion
}