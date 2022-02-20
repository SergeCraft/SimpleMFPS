using System;
using UnityEngine;
using Zenject;

public interface ITrophy: IDisposable
{
    #region Properties

    TrophyTypes Type { get; }
    
    int ID { get; }
    
    GameObject TrophyGameObject { get; }

    #endregion

    #region Methods

    

    #endregion

   
    
}