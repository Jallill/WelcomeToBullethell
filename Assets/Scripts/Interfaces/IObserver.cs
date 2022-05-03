
public interface IObserver<T>
{
    void OnNotify(T message, params object[] args);
}
