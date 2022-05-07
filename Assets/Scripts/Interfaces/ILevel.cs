
using System.Collections.Generic;

public interface ILevel
{
    public IWinCondition WinCondition { get; }

    public void StartLevel();
    public void EndLevel();
    public void NextLevel();
    public void BackToLobby();
}