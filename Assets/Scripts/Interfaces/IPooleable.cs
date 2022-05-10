using UnityEngine;

public delegate void PooleableEventHandler(object obj); 
public interface IPooleable
{
    public event PooleableEventHandler Release;
}