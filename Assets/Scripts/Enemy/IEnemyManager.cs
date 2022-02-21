using System;using System.Collections;
using System.Collections.Generic;
using UnityEngine;using Zenject;

public interface IEnemyManager
{
    #region Properties

    //List<IEnemy> Enemies { get; }
    List<MonoBehaviour> Enemies { get; }

    #endregion

    #region Methods
    
    void SpawnEnemy();

    #endregion

    #region Event handlers

    void OnEnemyDead(EnemyDeadSignal args);

    void OnGameRestart();

    #endregion
}
