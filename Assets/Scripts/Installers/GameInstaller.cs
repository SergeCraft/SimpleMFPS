using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class GameInstaller : MonoInstaller
{
	private GameObject _enemyPrefab;
	
	public override void InstallBindings()
	{
		Debug.Log("Installing bindings...");
		
		_enemyPrefab = Resources.Load<GameObject>("Prefabs/Enemy1");
		
		Container.Bind<ISettingsManager>().To<SimpleSettingsManager>().AsSingle();
		Container.Bind<ISettings>().To<SimpleSettings>().AsSingle();
		Container.BindInterfacesAndSelfTo<SimpleGameManager>().AsSingle();
		Container.BindInterfacesAndSelfTo<SimplePlayerManager>().AsSingle();
		//Container.BindInterfacesTo<SimpleTrophy>().AsTransient();
		Container.BindInterfacesAndSelfTo<SimpleTrophyManager>().AsSingle();
		Container.BindInterfacesTo<SimpleEnemyManager>().AsSingle();
		Container.BindFactory<Vector3, Enemy1Controller, 
				Enemy1Controller.Factory>()
			.FromComponentInNewPrefab(_enemyPrefab);
		// Container.BindInterfacesTo<SimpleEnemy>().AsTransient();
		// Container.BindInterfacesTo<SimpleBulletManager>().AsSingle();
		// Container.BindInterfacesTo<SimpleBullet>().AsTransient();
		Container.BindInstance(new Vector3(0.0f, 0.0f, 0.0f));

		SignalBusInstaller.Install(Container);
		
		//Container.DeclareSignal<TestGameEvent>();
		Container.DeclareSignal<PlayerHitSignal>();
		Container.DeclareSignal<PlayerDeadSignal>();
		Container.DeclareSignal<GameRestartSignal>();
		Container.DeclareSignal<TrophyPickedSignal>();
		Container.DeclareSignal<EnemyDeadSignal>();

		Debug.Log("Bindings installed successfully");
	}
}
