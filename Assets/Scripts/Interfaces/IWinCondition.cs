
public interface IWinCondition : IObservable<bool>
{
    public void ExecuteWin();
    public void ExecuteGameOver();
    public void CheckWinCondition();
    public void CheckLoseCondition();
}