
using UnityEngine.PlayerLoop;

public interface IGroundTile
{
    public bool Fallen { get; }
    public void ResetPosition();
    public void Fall();
}