using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Zenject;
using Random = UnityEngine.Random;

public class SimpleTrophyManager : ITrophyManager, IDisposable
{
    #region Fields

    private SignalBus _signalBus;

    private int _lastID;

    #endregion

    #region Properties

    public List<ITrophy> Trophies { get; private set; }

    #endregion

    #region Constructors

    public SimpleTrophyManager(SignalBus signalBus)
    {
        _signalBus = signalBus;
        _signalBus.Subscribe<GameRestartSignal>(OnGameRestart);
        _signalBus.Subscribe<EnemyDeadSignal>(OnEnemyDead);
        _signalBus.Subscribe<TrophyPickedSignal>(OnPlayerPickedTrophy);

        _lastID = 0;

        Trophies = new List<ITrophy>();
        
        Debug.Log("Simple trophy manager instantiated");
    }

    

    #endregion

    #region Public methods
    
    public void Dispose()
    {
        _signalBus.Unsubscribe<GameRestartSignal>(OnGameRestart);
        _signalBus.Unsubscribe<EnemyDeadSignal>(OnEnemyDead);
        _signalBus.Unsubscribe<TrophyPickedSignal>(OnPlayerPickedTrophy);
    }
    
    #endregion

    #region Private methods


    #endregion

    #region Event handlers
    
    public void OnGameRestart()
    {
        Trophies = new List<ITrophy>();
    }

    public void OnEnemyDead(EnemyDeadSignal args)
    {
        TrophyTypes randomTrophyType = (TrophyTypes) Random.Range(1, 3);
        Trophies.Add(new SimpleTrophy(
            _lastID++,
            args.Enemy.EnemyGameObject.transform.position));
    }

    public void OnPlayerPickedTrophy(TrophyPickedSignal args)
    {
        Trophies.RemoveAll(x => x.ID == args.TrophyID);
    }
    
    #endregion

}