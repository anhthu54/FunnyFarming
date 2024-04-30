using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSowAbility : MonoBehaviour
{
    [Header (" Elements ")]
    private PlayerAnimator playerAnimator;

    [Header (" Setting ")]
    private CropField currentCropField;

    void Start(){
        playerAnimator = GetComponent<PlayerAnimator>();

        SeedPracticles.onSeedsCollided += SeedsCollidedCallback;
        CropField.onFullySownField += FullSownCallback;
    }

    private void OnDestroy(){
        SeedPracticles.onSeedsCollided -= SeedsCollidedCallback;
        CropField.onFullySownField -= FullSownCallback;
    }

    private void FullSownCallback(CropField cropField){
        if(cropField == currentCropField){
            playerAnimator.StopSowAnimation();
        }
    }

    private void SeedsCollidedCallback(Vector3[] seedPositions){
        if(currentCropField == null){
            return;
        }
        currentCropField.SeedsCollidedCallback(seedPositions);
    }

    private void OnTriggerEnter(Collider other){
        if(other.CompareTag("CropField") && other.GetComponent<CropField>().isEmpty()){
            playerAnimator.SowAnimation();
            currentCropField = other.GetComponent<CropField>();
        }
    }

    private void OnTriggerExit(Collider other){
        if(other.CompareTag("CropField")){
            playerAnimator.StopSowAnimation();
            currentCropField = null;
        }
    }
}
