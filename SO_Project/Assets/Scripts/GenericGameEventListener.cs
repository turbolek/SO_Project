using Sirenix.OdinInspector;
using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public abstract class GenericGameEventListener<T> : SerializedMonoBehaviour
{
    [SerializeField]
    protected GenericGameEvent<T> _triggerEvent;
    [SerializeField]
    private UnityEvent<T> _responseEvent;

    private void OnEnable()
    {
        _triggerEvent?.RegisterListener(this);
    }

    private void OnDisable()
    {
        _triggerEvent.UnregisterListener(this);
    }

    public void OnEventRaised(T arg)
    {
        _responseEvent?.Invoke(arg);
    }
}
