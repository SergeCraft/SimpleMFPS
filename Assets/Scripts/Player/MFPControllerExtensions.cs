using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

[RequireComponent(typeof(CharacterController))]
public class MFPControllerExtensions : MonoBehaviour
{

    private SignalBus _signalBus;

    public void Construct(SignalBus signalBus)
    {
        _signalBus = signalBus;
    }
    
    // void Start()
    // {
    //     Debug.Log("MFPC extension pack greeting");
    // }

    // Update is called once per frame
    void Update()
    {
        
    }


    void OnControllerColliderHit(ControllerColliderHit hit)
    {
        switch (hit.gameObject.tag)
        {
            case "Level":
                break;
            case "Trophy":
                _signalBus.Fire(new TrophyPickedSignal(hit.gameObject.GetComponent<Trophy1Controller>().ID));
                break;
        }
    }
}
