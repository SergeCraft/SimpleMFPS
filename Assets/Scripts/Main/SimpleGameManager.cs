
using System.Collections.Generic;
using UnityEngine;

public class SimpleGameManager : IGameManager
{
    #region Fields

    private IPlayerManager _playerManager;

    #endregion

    #region Properties
    
    public GameStates State { get; private set; }
    
    public ISettings Settings { get; private set; }

    #endregion

    #region Constructors

    public SimpleGameManager(ISettings stg, IPlayerManager playerMgr)
    {
        State = GameStates.NotStarted;
        Settings = stg;
        _playerManager = playerMgr;
        StartGame();
    }


    #endregion

    #region Public methods

    

    #endregion

    #region Private methods

    private void StartGame()
    {
        _playerManager.SpawnPlayer();
        DisableStartCamera();
        State = GameStates.Play;
    }

    private void DisableStartCamera()
    {
        GameObject.Find("StartCamera").GetComponent<Camera>().enabled = false;
    }

    #endregion
}