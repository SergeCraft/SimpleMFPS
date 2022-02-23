
using System;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class SimpleGameManager : IGameManager, IDisposable, ITickable, IInitializable
{
    #region Fields

    private IPlayerManager _playerManager;
    private SignalBus _signalBus;

    #endregion

    #region Properties
    
    public GameStates State { get; private set; }
    
    public ISettings Settings { get; private set; }

    #endregion

    #region Constructors

    public SimpleGameManager(
        ISettings stg,
        IPlayerManager playerMgr,
        SignalBus signalBus)
    {
        State = GameStates.NotStarted;
        Settings = stg;
        _playerManager = playerMgr;
        _signalBus = signalBus;
    }


    #endregion

    #region Public methods

    public void Initialize()
    {
        StartGame();
    }


    public void Dispose()
    {
        ;
    }
    
    
    public void Tick()
    {
        ;
    }

    #endregion

    #region Private methods

    private void StartGame()
    {
        DisableStartCamera();
        State = GameStates.Started;
        Debug.Log("Game started");
        _signalBus.Fire<GameRestartSignal>();
    }

    private void DisableStartCamera()
    {
        GameObject.Find("StartCamera").GetComponent<Camera>().enabled = false;
    }

    #endregion

    #region Event handlers
    
    #endregion


}