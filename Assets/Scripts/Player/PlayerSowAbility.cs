using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSowAbility : MonoBehaviour
{
    [Header (" Elements ")]
    private PlayerAnimator playerAnimator;
    private PlayerSelectTool playerSelectTool;

    [Header (" Setting ")]
    private CropField currentCropField;

    void Start(){
        playerAnimator = GetComponent<PlayerAnimator>();
        playerSelectTool = GetComponent<PlayerSelectTool>();
        SeedParticles.onSeedsCollided += SeedsCollidedCallback;
        CropField.onFullySownField += FullSownCallback;
        playerSelectTool.onSelectedTool += SelectedToolCallback;
    }

    private void OnDestroy(){
        SeedParticles.onSeedsCollided -= SeedsCollidedCallback;
        CropField.onFullySownField -= FullSownCallback;
        playerSelectTool.onSelectedTool -= SelectedToolCallback;

    }

    private void SelectedToolCallback(PlayerSelectTool.Tool selectedTool){
        if(!playerSelectTool.CanSow()){
            playerAnimator.StopSowAnimation();
        }
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
        if(other.CompareTag("CropField") && other.GetComponent<CropField>().isEmpty() ){
            currentCropField = other.GetComponent<CropField>();
            EnteredField(currentCropField);
        }
    }

    private void EnteredField(CropField cropField){
        if(playerSelectTool.CanSow())
            playerAnimator.SowAnimation();
    }

    private void OnTriggerStay(Collider other){
        if(other.CompareTag("CropField"))
            EnteredField(other.GetComponent<CropField>());
    }

    private void OnTriggerExit(Collider other){
        if(other.CompareTag("CropField")){
            playerAnimator.StopSowAnimation();
            currentCropField = null;
        }
    }
}
