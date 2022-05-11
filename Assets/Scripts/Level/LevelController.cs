using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class LevelController : MonoBehaviour, ILevel, IObserver<bool>
{
    [SerializeField] private Levels _nextLevel;
    [SerializeField] private WinCondition _winCondition;
    [SerializeField] private float _timeBeforeLevelChange;
    
    public IWinCondition WinCondition => _winCondition;

    private void Start()
    {
        _winCondition.Subscribe(this);
        StartLevel();
    }

    public virtual void StartLevel()
    {
        
    }

    public virtual void EndLevel()
    {
        
    }

    public void NextLevel()
    {
        SceneManager.LoadScene(_nextLevel.ToString(), LoadSceneMode.Single);
    }

    public void BackToLobby()
    {
        SceneManager.LoadScene(Levels.Lobby.ToString(), LoadSceneMode.Single);
    }

    public void OnNotify(bool result, params object[] args)
    {
        
        EndLevel();
        if (result)
        {
            // Win logic
            // NextLevel();
        }
        else
        {
            //Game over logic
            Invoke(nameof(BackToLobby), _timeBeforeLevelChange);
        }
    }
}
