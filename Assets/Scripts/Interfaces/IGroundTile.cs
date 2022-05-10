
using UnityEngine;
using UnityEngine.PlayerLoop;

public interface IGroundTile
{
    public bool Fallen { get; }
    public Vector3 Position { get; }
    public Quaternion Rotation { get; }
    public void ResetPosition();
    public void Fall();
    
}