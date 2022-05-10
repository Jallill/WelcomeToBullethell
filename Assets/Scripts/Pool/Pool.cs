
using System.Collections.Generic;
using UnityEngine;

public class Pool<T, S> where T : IProduct<S>, IPooleable where S : ScriptableObject
{
    private Queue<T> _inactive = new Queue<T>();
    private List<T> _active = new List<T>();

    private IFactory<T, S> _objectFactory;

    public Pool(IFactory<T, S> objectFactory)
    {
        _objectFactory = objectFactory;
    }

    public T Get(S SO)
    {
        var obj = _inactive.Count > 0 ? _inactive.Dequeue() : _objectFactory.Create(SO);
        _active.Add(obj);
        obj.Data = SO;
        obj.Release += Release;

        return obj;
    }

    public void Release(object obj)
    {
        var item = (T)obj;
        if (!_active.Contains(item)) return;
        _inactive.Enqueue(item);
        _active.Remove(item);
        item.Release -= Release;
    }
}