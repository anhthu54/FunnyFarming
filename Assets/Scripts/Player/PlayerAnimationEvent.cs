using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimationEvent : MonoBehaviour
{
    
    [Header (" Elements")]
    [SerializeField]
    private ParticleSystem sowEffect;
    [SerializeField]
    private ParticleSystem waterEffect;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
    }

    void PlaySowEffect(){
        sowEffect.Play();
    }

    void PlayWaterEffect(){
        waterEffect.Play();
    }
}
