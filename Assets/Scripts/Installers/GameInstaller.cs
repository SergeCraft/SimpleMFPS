using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class GameInstaller : MonoInstaller
{
	private GameObject _enemyPrefab;
	private GameObject _bulletPrefab;
	private GameObject _trophyPrefab;
	
	public override void InstallBindings()
	{
		Debug.Log("Installing bindings...");
		
		_enemyPrefab = Resources.Load<GameObject>("Prefabs/Enemy1");
		_bulletPrefab = Resources.Load<GameObject>("Prefabs/Bullet1");
		_trophyPrefab = Resources.Load<GameObject>("Prefabs/Trophy1");
		
		Container.Bind<ISettingsManager>().To<SimpleSettingsManager>().AsSingle();
		Container.Bind<ISettings>().To<SimpleSettings>().AsSingle();
		Container.BindInterfacesAndSelfTo<SimpleGameManager>().AsSingle();
		Container.BindInterfacesAndSelfTo<SimplePlayerManager>().AsSingle();
		
		Container.BindInterfacesAndSelfTo<SimpleTrophyManager>().AsSingle();
		Container.BindFactory<Trophy1Controller.InitSettings, Trophy1Controller, 
				Trophy1Controller.Factory>()
		 	.FromComponentInNewPrefab(_trophyPrefab);
		
		Container.BindInterfacesTo<SimpleEnemyManager>().AsSingle();
		Container.BindFactory<Vector3, Enemy1Controller, 
				Enemy1Controller.Factory>()
			.FromComponentInNewPrefab(_enemyPrefab);
		
		Container.BindInterfacesTo<SimpleBulletManager>().AsSingle();
		Container.BindFactory<Bullet1Controller.InitSettings, Bullet1Controller, 
				Bullet1Controller.Factory>()
			.FromComponentInNewPrefab(_bulletPrefab);
		
		Container.BindInstance(new Vector3(0.0f, 0.0f, 0.0f));

		SignalBusInstaller.Install(Container);
		
		Container.DeclareSignal<PlayerHitSignal>();
		Container.DeclareSignal<PlayerDeadSignal>();
		Container.DeclareSignal<GameRestartSignal>();
		Container.DeclareSignal<TrophyPickedSignal>();
		Container.DeclareSignal<EnemyDeadSignal>();
		Container.DeclareSignal<PlayerShootSignal>();
		Container.DeclareSignal<BulletDestroySignal>();

		Debug.Log("Bindings installed successfully");
	}
}
