using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class VoidGameEventListener : MonoBehaviour
{
    [SerializeField]
    private VoidGameEvent _triggerEvent;
    [SerializeField]
    private UnityEvent _responseEvent;

    private void OnEnable()
    {
        _triggerEvent?.RegisterListener(this);
    }

    private void OnDisable()
    {
        _triggerEvent.UnregisterListener(this);
    }

    public void OnEventRaised()
    {
        _responseEvent?.Invoke();
    }
}
