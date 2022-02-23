using UnityEngine;

public interface IPlayerManager
{
    public IPlayer Player { get; }
    
    public void RespawnPlayer();

}