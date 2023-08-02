using System.Collections.Generic;
using UnityEngine;

public class ObjectPool<T> where T : MonoBehaviour
{
    private Stack<T> _poolStack = new Stack<T>();
    private T _prefab;
    private Transform _parent;

    public ObjectPool(T prefab, Transform parent, int initialSize)
    {
        _prefab = prefab;
        _parent = parent;

        for (int i = 0; i < initialSize; i++)
        {
            AddToPool();
        }
    }

    private void AddToPool()
    {
        T instance = GameObject.Instantiate(_prefab, _parent);
        ReturnToPool(instance);
    }

    public T GetFromPool(bool activate)
    {
        if (_poolStack.Count == 0)
        {
            AddToPool();
        }

        T instance = _poolStack.Pop();

        if (activate)
        {
            instance.gameObject.SetActive(true);
        }

        return instance;
    }

    public void ReturnToPool(T instance)
    {
        instance.gameObject.SetActive(false);
        _poolStack.Push(instance);
    }
}
