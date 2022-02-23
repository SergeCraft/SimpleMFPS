using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class SimpleWeapon : MonoBehaviour
{
    private SignalBus signalBus;
    
    private float delay;
    
    public FP_Input playerInput;

    public float shootRate = 0.15F;

    [Inject]
    public void Construct(SignalBus signalBus)
    {
        this.signalBus = signalBus;
    }
    
    void Start () 
    {
        
    }
	
    void Update () 
    {
        if(playerInput.Shoot())
            if(Time.time > delay)
                Shoot();
    }

    void Shoot()
    {
        Debug.Log("Simple bang");
        signalBus.Fire<PlayerShootSignal>();
        delay = Time.time + shootRate;
    }
}
