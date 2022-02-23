using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;
using Random = UnityEngine.Random;

public class SimpleEnemyManager : IEnemyManager, ITickable, IDisposable, IInitializable
{
    #region Fields

    private SignalBus _signalBus;
    private IGameManager _gameManager;
    private IPlayer _player;
    private Camera _playerCamera;
    private Transform _playerHead;
    private ISettings _settings;
    private Bounds _levelBounds;
    private float _lastSpawnTime;

    private readonly Enemy1Controller.Factory _enemyFactory;

    #endregion

    #region Properties

    public List<MonoBehaviour> Enemies { get; private set; }

    #endregion

    #region Constructors

    public SimpleEnemyManager(
        SignalBus signalBus,
        IGameManager gameManager,
        IPlayer player,
        ISettings settings,
        Enemy1Controller.Factory enemyFactory)
    {
        _signalBus = signalBus;
        _gameManager = gameManager;
        _player = player;
        _playerCamera = player.MFPController.transform.
            GetChild(0).GetChild(0).GetChild(0)
            .GetComponent<Camera>();
        _playerHead = player.MFPController.transform.GetChild(0).GetChild(0);
        _settings = settings;
        _levelBounds = GetLevelBounds();
        _lastSpawnTime = Time.time;
        _enemyFactory = enemyFactory;
        

        Enemies = new List<MonoBehaviour>();
        
        _signalBus.Subscribe<GameRestartSignal>(OnGameRestart);
        _signalBus.Subscribe<EnemyDeadSignal>(OnEnemyDead);
        
        Debug.Log("Simple enemy manager instantiated");
    }

    

    #endregion

    #region Public methods

    public void Initialize()
    {
        
    }
    
    public void Tick()
    {
        TrySpawnEnemy();
    }

    public void Dispose()
    {
        _signalBus.Unsubscribe<GameRestartSignal>(OnGameRestart);
        _signalBus.Unsubscribe<EnemyDeadSignal>(OnEnemyDead);
    }

    
    public void SpawnEnemy()
    {
        var spawnPosition = GetSpawnPosition();
        var enemy = _enemyFactory.Create(spawnPosition);
        Enemies.Add(enemy);
        _lastSpawnTime = Time.time;
        Debug.Log($"Enemy spawned at {spawnPosition}");
    }
    
    #endregion

    #region Private methods

    
    private Bounds GetLevelBounds()
    {
        var bounds = GameObject.Find("Level").GetComponentInChildren<MeshRenderer>().bounds;
        Debug.Log($"Level bounds defined: { bounds.min } : {bounds.max}");
        return bounds;
    }

    private void TrySpawnEnemy()
    {
        if(Time.time - _lastSpawnTime >= 3.0f) SpawnEnemy();
    }

    private Vector3 GetSpawnPosition()
    {
        float camFOVDegreesLeft = -_playerHead.eulerAngles.y + _playerCamera.fieldOfView;
        float camFOVDegreesRight = -_playerHead.eulerAngles.y - _playerCamera.fieldOfView;
        float spawnPositionDirection = Random.Range(camFOVDegreesRight, camFOVDegreesLeft) + 270;
        Vector3 playerPosition = _player.MFPController.transform.GetChild(0).position;
        Ray spawnPositionHorizontalRay = new Ray(
            new Vector3(playerPosition.x, 5.9f, playerPosition.z),
            Helper.DegreeToVector3(spawnPositionDirection));
        RaycastHit hit;
        Physics.Raycast(spawnPositionHorizontalRay, out hit);
        Vector3 spawnHorizontalPosition = spawnPositionHorizontalRay
            .GetPoint(hit.distance * Random.Range(0.3f, 0.9f));
        
        Ray spawnPositionVerticalalRay = new Ray(
            spawnHorizontalPosition, Vector3.down);
        Physics.Raycast(spawnPositionVerticalalRay, out hit);
        Vector3 spawnPosition = hit.point + new Vector3(0.0f, 0.5f, 0.0f);

        return spawnPosition;
    }

    #endregion

    #region Event handlers

    public void OnEnemyDead(EnemyDeadSignal args)
    {
        Enemies.Remove(args.Enemy);
        GameObject.Destroy(args.Enemy.gameObject);
    }

    public void OnGameRestart()
    {
        foreach (var enemy in Enemies)
        {
            GameObject.Destroy(enemy.gameObject);
        }
        Enemies = new List<MonoBehaviour>();
        
    }

    #endregion




}
