using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSowAbility : MonoBehaviour
{
    [Header (" Elements ")]
    private PlayerAnimator playerAnimator;

    void Start(){
        playerAnimator = GetComponent<PlayerAnimator>();
    }

    private void OnTriggerEnter(Collider other){
        if(other.CompareTag("CropField")){
            playerAnimator.SowAnimation();
        }
    }

    private void OnTriggerExit(Collider other){
        if(other.CompareTag("CropField")){
            playerAnimator.StopSowAnimation();
        }
    }
}
