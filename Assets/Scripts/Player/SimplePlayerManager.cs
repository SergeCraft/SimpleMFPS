using UnityEngine;

public class SimplePlayerManager: IPlayerManager
{
    #region Fields

    private ISettings _settings;

    private GameObject _playerPrefab;

    #endregion
    
    #region Properties

    public GameObject Player { get; private set; }

    public PlayerStates Sate { get; private set; }
    
    #endregion

    #region Constructors

    public SimplePlayerManager(ISettings stg)
    {
        _settings = stg;
        _playerPrefab = GetPlayerPrefab();
    }


    #endregion
    
    
    #region Public methods

    public void SpawnPlayer()
    {
        Player = GameObject.Instantiate(
            _playerPrefab,
            _settings.PlayerInitialPosition,
            Quaternion.identity);
        
        DisableReloadButton(Player);
        ResizeCharacter(Player);
        SetSimpleWeapon(Player);
        
    }

    public void DestroyPlayer()
    {
        throw new System.NotImplementedException();
    }
    #endregion

    #region Private methods
    
    private GameObject GetPlayerPrefab()
    {
        return Resources.Load<GameObject>("Prefabs/3rdParty/EYESTRIP/MFPC/MFPController");
    }

    private static void SetSimpleWeapon(GameObject prefab)
    {
        prefab.transform.GetChild(0).GetChild(0).GetChild(1).GetChild(0).gameObject.SetActive(false);
        var fPInput = prefab.GetComponentInChildren<FP_Input>();
        var weapon = new GameObject();
        weapon.name = "SimpleWeapon";
        weapon.AddComponent<SimpleWeaponScript>();
        weapon.GetComponent<SimpleWeaponScript>().playerInput = fPInput;
        weapon.transform.SetParent(
            prefab.transform.GetChild(0).GetChild(0).GetChild(1));
    }

    private static void ResizeCharacter(GameObject prefab)
    {
        var CharCtl = prefab.GetComponentInChildren<CharacterController>();
        CharCtl.radius = 0.4f;
        CharCtl.height = 1.8f;
    }

    private void DisableReloadButton(GameObject prefab)
    {
        prefab.transform.GetChild(1).GetChild(4).gameObject.SetActive(false);
    }

    #endregion
}