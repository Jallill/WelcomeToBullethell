using System.Collections.Generic;
using UnityEngine;

public class WinCondition : MonoBehaviour, IWinCondition
{
    private List<IObserver<bool>> _subscribers = new List<IObserver<bool>>();
    public List<IObserver<bool>> Subscribers => _subscribers;
    
    public virtual void ExecuteWin()
    {
        NotifyAll(true);
    }

    public virtual void ExecuteGameOver()
    {
        NotifyAll(false);
    }

    public virtual void CheckWinCondition()
    {
        
    }

    public virtual void CheckLoseCondition()
    {
        
    }

    public void Subscribe(IObserver<bool> observer)
    {
        if (_subscribers.Contains(observer)) return;
        _subscribers.Add(observer);
    }

    public void Unsubscribe(IObserver<bool> observer)
    {
        if (!_subscribers.Contains(observer)) return;
        _subscribers.Remove(observer);
    }

    public void NotifyAll(bool message, params object[] args)
    {
        _subscribers.ForEach((observer) => {observer.OnNotify(message);});
    }
}