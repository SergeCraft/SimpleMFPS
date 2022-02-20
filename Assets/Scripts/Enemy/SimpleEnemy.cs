
using UnityEngine;

public class SimpleEnemy: IEnemy
{
    #region Fields

    

    #endregion

    #region Properties
    
    public GameObject EnemyGameObject { get; }

    #endregion

    #region Constructors

    

    #endregion

    #region Public methods
    
    public void Dispose()
    {
        GameObject.Destroy(EnemyGameObject);
    }

    #endregion

    #region Private methods

    

    #endregion

    #region Event handlers

    

    #endregion

}