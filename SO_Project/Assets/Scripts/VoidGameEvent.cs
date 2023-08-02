using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class VoidGameEvent : ScriptableObject
{
    private List<VoidGameEventListener> _listeners = new List<VoidGameEventListener>();

    public void RegisterListener(VoidGameEventListener listener)
    {
        if (!_listeners.Contains(listener))
        {
            _listeners.Add(listener);
        }
    }

    public void UnregisterListener(VoidGameEventListener listener)
    {
        if (_listeners.Contains(listener))
        {
            _listeners.Remove(listener);
        }
    }

    public void Raise()
    {
        for (int i = _listeners.Count - 1; i >= 0; i--)
        {
            _listeners[i]?.OnEventRaised();
        }
    }
}
