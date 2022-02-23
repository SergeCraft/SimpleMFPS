using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class SimpleWeapon : MonoBehaviour
{
    private SignalBus _signalBus;
    
    private float delay;
    
    public FP_Input playerInput;

    public float shootRate;

    public AudioSource audioSource;

    [Inject]
    public void Construct(SignalBus signalBus)
    {
        _signalBus = signalBus;
        audioSource = GetComponent<AudioSource>();
    }
    
	
    void Update () 
    {
        if(playerInput.Shoot() && Time.time > delay) Shoot();
    }

    void Shoot()
    {
        delay = Time.time + shootRate;
        _signalBus.Fire<PlayerShootSignal>();
        audioSource.Play();
    }
}
