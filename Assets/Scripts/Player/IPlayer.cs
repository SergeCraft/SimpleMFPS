using System;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public interface IPlayer
{
    
    
    
    #region Properties

    GameObject MFPController { get; }

    int HP { get; }
    
    List<int> Score { get; }
    
    SignalBus SignalBus { get; }
    
    PlayerStates State { get; }

    #endregion

    #region Methods

    void Respawn();

    #endregion

    #region Event handlers

    void OnPlayerTakeHit(PlayerHitSignal args);

    #endregion

}