
using System;
using UnityEngine;

public interface IEnemy: IDisposable
{
    #region Properties

    GameObject EnemyGameObject { get; }
    
    int HP { get; }

    #endregion

    #region Methods

    

    #endregion

    #region Event handlers

    

    #endregion
}