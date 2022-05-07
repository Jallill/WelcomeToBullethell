using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class KillThemAllCondition : WinCondition, IObserver<bool>
{
    [SerializeField] private List<Enemy> _enemiesToKill;
    [SerializeField] private PlayerController _playerController;

    private void Start()
    {
        _playerController.Subscribe(this);
    }

    public override void CheckWinCondition()
    {
        base.CheckWinCondition();
        if (_enemiesToKill.All((enemy) => enemy.IsDead())) //TODO: Create EnemiesController observable where it notifies when all enemies are dead (facade?)
        {
            ExecuteWin();
        }
    }

    private void Update()
    {
        CheckWinCondition();
    }

    public override void CheckLoseCondition()
    {
        base.CheckLoseCondition();
        if (_playerController.IsDead)
        {
            ExecuteGameOver();
        }
    }

    public void OnNotify(bool message, params object[] args)
    {
        CheckLoseCondition();
    }
}