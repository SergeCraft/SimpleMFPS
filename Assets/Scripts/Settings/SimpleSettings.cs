
using UnityEngine;
using Zenject;

public class SimpleSettings: ISettings
{

    #region Properties

    public float InitialEnemySpeed { get; private set; }

    public int EnemyMaxCount { get; private set; }

    public int EnemyMinCount { get; private set; }

    public float EnemyInitialHP { get; private set; }

    public Vector3 PlayerInitialPosition { get; private set; }
    
    #endregion

    #region Constructors

    public SimpleSettings()
    {
        ResetToDefault();
    }



    #endregion

    #region Public Methods

    public void ResetToDefault()
    {
        InitialEnemySpeed = 1.0f;
        EnemyMaxCount = 3;
        EnemyMinCount = 1;
        EnemyInitialHP = 100.0f;
        PlayerInitialPosition = new Vector3(0.0f, 1.2f, 0.0f);
    }

    #endregion

    #region Private methods

    

    #endregion
}
