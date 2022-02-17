using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleWeaponScript : MonoBehaviour
{
    public FP_Input playerInput;

    public float shootRate = 0.15F;

    private float delay;

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
        delay = Time.time + shootRate;
    }
}
