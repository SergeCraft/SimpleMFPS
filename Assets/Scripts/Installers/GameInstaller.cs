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
		
		Debug.Log("Bindings installed successfully");
	}
}
