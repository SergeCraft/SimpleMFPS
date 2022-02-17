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
		Container.Bind<IGameManager>().To<SimpleGameManager>().AsSingle();
		
		Debug.Log("Bindings installed successfully");
	}
}
