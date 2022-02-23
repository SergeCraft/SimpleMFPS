using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class SimpleWeapon : MonoBehaviour
{
    private SignalBus signalBus;
    
    private float delay;
    
    public FP_Input playerInput;

    public float shootRate;

    [Inject]
    public void Construct(SignalBus signalBus)
    {
        this.signalBus = signalBus;
    }
    
	
    void Update () 
    {
        if(playerInput.Shoot() && Time.time > delay) Shoot();
    }

    void Shoot()
    {
        delay = Time.time + shootRate;
        signalBus.Fire<PlayerShootSignal>();
    }
}
