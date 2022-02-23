
using System;
using UnityEngine;
using Zenject;

public class SimpleBulletManager: IBulletManager, IDisposable
{
    #region Fields

    private SignalBus _signalBus;
    private Bullet1Controller.Factory _bulletFactory;
    private Transform _playerTransform;
    private IPlayer _player;
    private Color _actualColor;
    
    #endregion

    #region Constructors

    public SimpleBulletManager(SignalBus signalBus, Bullet1Controller.Factory factory, IPlayer player)
    {
        _signalBus = signalBus;
        _bulletFactory = factory;
        _player = player;
        _playerTransform = player.MFPController.transform.GetChild(0);
        _actualColor = Color.black;
        
        _signalBus.Subscribe<PlayerShootSignal>(OnPlayerShoot);
        _signalBus.Subscribe<BulletDestroySignal>(OnBulletDestroy);
        _signalBus.Subscribe<TrophyPickedSignal>(OnTrophyPicked);
    }


    #endregion

    #region Public methods

    public void Dispose()
    {
        
        _signalBus.Unsubscribe<PlayerShootSignal>(OnPlayerShoot);
        _signalBus.Unsubscribe<BulletDestroySignal>(OnBulletDestroy);
    }

    #endregion

    #region Private methods
    
    private void SpawnBullet()
    {
        _bulletFactory.Create(new Bullet1Controller.InitSettings(
            _actualColor,
            _playerTransform.GetChild(0).forward,
            _playerTransform.position + _playerTransform.GetChild(0).forward));
    }

    #endregion
    
    #region EventHandlers

    
    private void OnBulletDestroy(BulletDestroySignal args)
    {
        Debug.Log("Manager heard that bullet destroyed");
        GameObject.Destroy(args.Bullet.gameObject);
    }


    private void OnPlayerShoot(PlayerShootSignal args)
    {
        SpawnBullet();
    }
    
    private void OnTrophyPicked(TrophyPickedSignal args)
    {
        _actualColor = Helper.TrophyTypeToColor(args.Trophy.GetComponent<Trophy1Controller>().Type);
    }

    #endregion
}