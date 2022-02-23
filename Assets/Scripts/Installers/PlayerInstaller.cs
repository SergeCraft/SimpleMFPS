using UnityEngine;
using Zenject;

public class PlayerInstaller: MonoInstaller
{
    public override void InstallBindings()
    {
        Debug.Log("Installing Player bindings...");

        Container.BindInterfacesTo<SimplePlayer>().AsSingle();
        
        Container.InstantiatePrefabResource("Prefabs/3rdParty/EYESTRIP/MFPC/MFPControllerMod");
        
        Debug.Log("Player bindings installed successfully");
    }
}