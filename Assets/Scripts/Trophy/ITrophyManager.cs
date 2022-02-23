
using System;
using System.Collections.Generic;
using UnityEngine;

public interface ITrophyManager
{
    #region Properties

    List<MonoBehaviour> Trophies { get; }

    #endregion

    #region Methods

    

    #endregion

    #region Event handlers

    public void OnGameRestart();

    public void OnEnemyDead(EnemyDeadSignal args);

    public void OnPlayerPickedTrophy(TrophyPickedSignal args);

    #endregion

}