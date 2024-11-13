using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerAnimationEvent : MonoBehaviour
{
    
    [Header (" Elements")]
    [SerializeField]
    private ParticleSystem sowEffect;
    [SerializeField]
    private ParticleSystem waterEffect;

    [SerializeField] private UnityEvent onStartHarvestEvent;
    [SerializeField] private UnityEvent onStopHarvestEvent;
    
    void PlaySowEffect(){
        sowEffect.Play();
    }

    void PlayWaterEffect(){
        waterEffect.Play();
    }

    void OnStartHarvestEvent()
    {
        onStartHarvestEvent?.Invoke();
    }

    void OnStopharvestEvent()
    {
        onStopHarvestEvent?.Invoke();
    }
}
