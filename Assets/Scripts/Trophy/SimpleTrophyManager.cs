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
    private Trophy1Controller.Factory _factory;
    private Vector3 _positionOffset = new Vector3(0.0f, 1.0f, 0.0f);

    #endregion

    #region Properties

    public List<MonoBehaviour> Trophies { get; private set; }

    #endregion

    #region Constructors

    public SimpleTrophyManager(SignalBus signalBus, Trophy1Controller.Factory trophyFactory)
    {
        _signalBus = signalBus;
        _factory = trophyFactory;
        
        _signalBus.Subscribe<GameRestartSignal>(OnGameRestart);
        _signalBus.Subscribe<EnemyDeadSignal>(OnEnemyDead);
        _signalBus.Subscribe<TrophyPickedSignal>(OnPlayerPickedTrophy);

        Trophies = new List<MonoBehaviour>();
        
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

    private void SpawnTrophy(Vector3 initPosition)
    {
        Trophies.Add(_factory.Create(new Trophy1Controller.InitSettings(
            initPosition + _positionOffset)));
    }

    #endregion

    #region Event handlers
    
    public void OnGameRestart()
    {
        foreach (var trophy in Trophies)
        {
            GameObject.Destroy(trophy.gameObject);
        }
        Trophies = new List<MonoBehaviour>();
    }

    public void OnEnemyDead(EnemyDeadSignal args)
    {
        SpawnTrophy(args.Enemy.transform.position);
    }


    public void OnPlayerPickedTrophy(TrophyPickedSignal args)
    {
        Trophies.Remove(args.Trophy);
        GameObject.Destroy(args.Trophy.gameObject);
    }
    
    #endregion

}