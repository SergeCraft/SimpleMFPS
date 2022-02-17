using UnityEngine;

public interface IPlayerManager
{
    public GameObject Player { get; }
    
    public PlayerStates Sate { get; }

    public void SpawnPlayer();

    public void DestroyPlayer();

}