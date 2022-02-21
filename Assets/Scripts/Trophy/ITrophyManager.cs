
using System;
using System.Collections.Generic;

public interface ITrophyManager
{
    #region Properties

    List<ITrophy> Trophies { get; }

    #endregion

    #region Methods

    

    #endregion

    #region Event handlers

    public void OnGameRestart();

    public void OnEnemyDead(EnemyDeadSignal args);

    public void OnPlayerPickedTrophy(TrophyPickedSignal args);

    #endregion

}