
using System;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class SimpleGameManager : IGameManager, IInitializable, IDisposable, ITickable
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
        StartGame();
    }


    #endregion

    #region Public methods

    
    public void Initialize()
    {
        _signalBus.Subscribe<TestGameEvent>(TestEventHandler);
    }


    public void Dispose()
    {
        _signalBus.Unsubscribe<TestGameEvent>(TestEventHandler);
    }

    #endregion

    #region Private methods

    private void StartGame()
    {
        DisableStartCamera();
        State = GameStates.Started;
    }

    private void DisableStartCamera()
    {
        GameObject.Find("StartCamera").GetComponent<Camera>().enabled = false;
    }

    #endregion

    #region Event handlers
    
    private void TestEventHandler()
    {
        Debug.Log("Test event fired");
    }

    #endregion

    public void Tick()
    {
        ;
    }
}