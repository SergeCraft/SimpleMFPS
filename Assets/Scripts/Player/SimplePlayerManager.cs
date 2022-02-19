using System;
using System.ComponentModel;
using UnityEngine;
using Zenject;

public class SimplePlayerManager: IPlayerManager, IDisposable
{
    #region Fields

    private ISettings _settings;

    private SignalBus _signalBus;

    #endregion
    
    #region Properties

    public IPlayer Player { get; private set; }
    
    #endregion

    #region Constructors

    public SimplePlayerManager(ISettings stg, SignalBus signalBus, IPlayer player)
    {
        _settings = stg;
        _signalBus = signalBus;
        Player = player;
        
        _signalBus.Subscribe<PlayerDeadSignal>(OnPlayerDead);
        
        RespawnPlayer();
    }

    #endregion
    
    
    #region Public methods

    public void RespawnPlayer()
    {
        Player.Respawn();
    }

    public void Dispose()
    {
        _signalBus.Unsubscribe<PlayerDeadSignal>(OnPlayerDead);
    }
    
    #endregion

    #region Private methods
    



    #endregion


    #region Event handlers

    
    private void OnPlayerDead(PlayerDeadSignal obj)
    {
        Debug.Log("PlayerDead");
        RespawnPlayer();
    }


    #endregion
}