
using System;
using Zenject;

public interface IGameManager
{
    public GameStates State { get; }
    
    public ISettings Settings { get; }
}
