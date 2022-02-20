using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class GameInstaller : MonoInstaller
{
	public override void InstallBindings()
	{
		Debug.Log("Installing bindings...");
		
		Container.Bind<ISettingsManager>().To<SimpleSettingsManager>().AsSingle();
		Container.Bind<ISettings>().To<SimpleSettings>().AsSingle();
		Container.Bind<IPlayerManager>().To<SimplePlayerManager>().AsSingle();
		Container.BindInterfacesAndSelfTo<SimpleGameManager>().AsSingle();
		//Container.BindInterfacesTo<SimpleTrophy>().AsTransient();
		Container.BindInterfacesTo<SimpleTrophyManager>().AsSingle();

		SignalBusInstaller.Install(Container);
		
		Container.DeclareSignal<TestGameEvent>();
		Container.DeclareSignal<PlayerHitSignal>();
		Container.DeclareSignal<PlayerDeadSignal>();
		Container.DeclareSignal<GameRestartSignal>();
		Container.DeclareSignal<TrophyPickedSignal>();
		Container.DeclareSignal<EnemyDeadSignal>();

		Debug.Log("Bindings installed successfully");
	}
}
