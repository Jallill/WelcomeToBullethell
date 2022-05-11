using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.InputSystem;
using Random = UnityEngine.Random;

public class GroundController : MonoBehaviour
{
    [SerializeField] private float _throwTilesSpeed;

    private List<IGroundTile> _groundTiles = new List<IGroundTile>();
    private float _timer;
    
    private List<IGroundTile> _fallenTiles = new List<IGroundTile>();
    
    private void Awake()
    {
        _timer = _throwTilesSpeed;
        if (_groundTiles.Count <= 0)
        {
            _groundTiles = GetComponentsInChildren<IGroundTile>().ToList();
        }
    }

    private void FallResetRandomTile()
    {
        var index = Random.Range(0, _groundTiles.Count);
        if (_groundTiles[index].Fallen)
        {
            _groundTiles[index].ResetPosition();
        }
        else
        {
            _groundTiles[index].Fall();
        }
        _fallenTiles.Add(_groundTiles[index]);
    }

    private void ThrowTile()
    {
        var _availableTiles =  _groundTiles.Where((tile) => !tile.Fallen && !tile.PlayerOnMe).ToList();
        if (_availableTiles.Count == 0)
        {
            _groundTiles[0].Fall();
            return;
        }
        var index = Random.Range(0, _availableTiles.Count);
        _availableTiles[index].Fall();
    }
    
    private void Update()
    {
        if (Keyboard.current.f1Key.wasPressedThisFrame)
        {
            ThrowTile();
        }

        if (_timer <= 0)
        {
            ThrowTile();
            _timer = _throwTilesSpeed;
        }

        _timer -= Time.deltaTime;
    }
}
