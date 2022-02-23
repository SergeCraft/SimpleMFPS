using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

[RequireComponent(typeof(CharacterController))]
public class MFPControllerExtensions : MonoBehaviour
{

    private SignalBus _signalBus;
    public AudioClip _pickupSound;
    private AudioSource _audioSource;

    [Inject]
    public void Construct(SignalBus signalBus)
    {
        _signalBus = signalBus;
        _audioSource = GetComponent<AudioSource>();
    }
    
    


    void OnControllerColliderHit(ControllerColliderHit hit)
    {
        switch (hit.gameObject.tag)
        {
            case "Level":
                break;
            case "Trophy":
                _signalBus.Fire(new TrophyPickedSignal(hit.gameObject.GetComponent<Trophy1Controller>()));
                PlayPickupSound();
                break;
        }
    }

    private void PlayPickupSound()
    {
        _audioSource.clip = _pickupSound;
        _audioSource.Play();
    }

    public void OnAnimationEvent(string message)
    {
        Debug.Log(message);
    }
}
