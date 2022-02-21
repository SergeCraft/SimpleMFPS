
using UnityEngine;
using Zenject;

public class SimpleEnemy: IEnemy
{
    #region Fields

    private SignalBus _signalBus;

    #endregion

    #region Properties
    
    public GameObject EnemyGameObject { get; }
    
    public int HP { get; private set; }

    #endregion

    #region Constructors

    public SimpleEnemy(SignalBus signalBus, Vector3 initPosition, GameObject prefab)
    {
        _signalBus = signalBus;

        EnemyGameObject = GameObject.Instantiate(prefab, initPosition, Quaternion.identity);
        
        HP = 100;
    }    

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