using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GameEventListener : MonoBehaviour
{
    [SerializeField]
    private GameEvent _triggerEvent;
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
