using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.InputSystem;
using Random = UnityEngine.Random;

public class GroundController : MonoBehaviour
{
    [SerializeField] private List<IGroundTile> _groundTiles = new List<IGroundTile>();

    private List<IGroundTile> _fallenTiles = new List<IGroundTile>();
    
    private void Awake()
    {
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
    
    private void Update()
    {
        if (Keyboard.current.f1Key.wasPressedThisFrame)
        {
            FallResetRandomTile();
        }
    }
}
