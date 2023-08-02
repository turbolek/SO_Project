using Sirenix.OdinInspector;
using System.Collections.Generic;

public abstract class GenericGameEvent<T> : SerializedScriptableObject
{
    private List<GenericGameEventListener<T>> _listeners = new List<GenericGameEventListener<T>>();

    public void RegisterListener(GenericGameEventListener<T> listener)
    {
        if (!_listeners.Contains(listener))
        {
            _listeners.Add(listener);
        }
    }

    public void UnregisterListener(GenericGameEventListener<T> listener)
    {
        if (_listeners.Contains(listener))
        {
            _listeners.Remove(listener);
        }
    }

    public void Raise(T arg)
    {
        for (int i = _listeners.Count - 1; i >= 0; i--)
        {
            _listeners[i]?.OnEventRaised(arg);
        }
    }
}
