using System;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using Vector3 = UnityEngine.Vector3;

public class PlayerAnimator : MonoBehaviour
{
    [Header(" Elements ")]
    [SerializeField]
    private Animator anim;
    [SerializeField]
    private float speedMultiplier;


    void Start()
    {
    }

    public void ManageAnimations(Vector3 move){
        if(move.magnitude > 0){
            anim.SetFloat("speed", move.magnitude * speedMultiplier);
            RunAnimation();
            anim.transform.forward = move.normalized;
        }   
        else {
            IdleAnimation();
        }
        

        
    }

    void RunAnimation(){
        anim.Play("Run");
    }

    void IdleAnimation(){
        anim.Play("Idle");
    }

    
    public void SowAnimation(){
        anim.SetLayerWeight(1,1);
    }

    public void StopSowAnimation(){
        anim.SetLayerWeight(1,0);
    }
    public void WaterAnimation(){
        anim.SetLayerWeight(2,1);
    }

    public void StopWaterAnimation(){
        anim.SetLayerWeight(2,0);
    }
}

