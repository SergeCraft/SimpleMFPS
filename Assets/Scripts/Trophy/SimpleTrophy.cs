
using UnityEngine;
using Zenject;

public class SimpleTrophy : ITrophy
{

    #region Fields

    

    #endregion
    
    #region Properties
    
    public TrophyTypes Type { get; private set; }
    public GameObject TrophyGameObject { get; private set; }
    
    public int ID { get; private set; }

    #endregion


    #region Constructors

    public SimpleTrophy(
        int iD,
        Vector3 initPosition,
        TrophyTypes type = TrophyTypes.Undefined)
    {
        ID = iD;
        Type = type;
        TrophyGameObject = Resources.Load<GameObject>("Prefabs/Trophy1");
        TrophyGameObject.transform.position = new Vector3(0.0f, 2.0f, 0.0f);
    }

    #endregion
    
    #region Public Methods


    public void Dispose()
    {
        GameObject.Destroy(TrophyGameObject);
    }
    
    #endregion

    
}