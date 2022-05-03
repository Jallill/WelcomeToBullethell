using System.Collections.Generic;

public interface IObservable<T>
{
    List<IObserver<T>> Subscribers { get; }

    void Subscribe(IObserver<T> observer);
    void Unsubscribe(IObserver<T> observer);

    void NotifyAll(T message, params object[] args);
}
