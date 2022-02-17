using UnityEngine;

public interface ISettings
{
    #region Properties

    public float InitialEnemySpeed { get; }

    public int EnemyMaxCount { get; }

    public int EnemyMinCount { get; }

    public float EnemyInitialHP { get; }

    public Vector3 PlayerInitialPosition { get; }
    
    #endregion


    #region Methods

    public void ResetToDefault();

    #endregion
}
