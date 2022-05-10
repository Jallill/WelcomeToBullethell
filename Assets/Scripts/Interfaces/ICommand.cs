
using UnityEngine;

public interface ICommand
{
    public void Do();
}

public interface ICommand<T>
{
    public void Do(T parammeter);
}