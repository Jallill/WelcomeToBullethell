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
    [SerializeField] private LayerMask _playerLayer;

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

    private void ThrowTile(List<IGroundTile> occupied = null)
    {
        var _availableTiles = occupied == null ? 
            _groundTiles.Where((tile) => !tile.Fallen).ToList() : 
            _groundTiles.Where((tile) => !tile.Fallen && !occupied.Contains(tile)).ToList();
        switch (_availableTiles.Count)
        {
            case 0:
                return;
            case 1:
                _availableTiles[0].Fall();
                return;
        }
        var index = Random.Range(0, _availableTiles.Count);
        var result = Physics.CheckBox(_availableTiles[index].Position, Vector3.one / 2,
            _availableTiles[index].Rotation, _playerLayer);
        if (result)
        {
            Debug.Log("FOUND PLAYER STANDING ON TILE");
            if (occupied == null) occupied = new List<IGroundTile>();
            occupied.Add(_groundTiles[index]);
            ThrowTile(occupied);
            return;
        }
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
