using UnityEngine;
using UnityEngine.SceneManagement;

public class LobbyController : MonoBehaviour, ILevel
{
    [SerializeField] private Levels _firstLevel;
    
    public IWinCondition WinCondition { get; }
    
    public void StartLevel()
    {
        
    }

    public void EndLevel()
    {
        
    }

    public void NextLevel()
    {
        SceneManager.LoadScene(_firstLevel.ToString(), LoadSceneMode.Single);
    }

    public void BackToLobby()
    {
        throw new System.NotImplementedException();
    }
}