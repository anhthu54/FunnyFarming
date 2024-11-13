using UnityEngine;

public class PlayerWaterAbility : MonoBehaviour
{
    [Header (" Elements ")]
    private PlayerAnimator playerAnimator;
    private PlayerSelectTool playerSelectTool;

    [Header (" Setting ")]
    private CropField currentCropField;
    void Start()
    {
        playerAnimator = GetComponent<PlayerAnimator>();
        playerSelectTool = GetComponent<PlayerSelectTool>();

        WaterPacticles.onWaterCollided += WaterCollidedCallback;
        playerSelectTool.onSelectedTool += SelectedToolCallback;
        CropField.onFullyGrownField += FullGrownCallback;
    }

    void OnDestroy(){
        WaterPacticles.onWaterCollided -= WaterCollidedCallback;
        playerSelectTool.onSelectedTool -= SelectedToolCallback;
        CropField.onFullyGrownField -= FullGrownCallback;
    }

    void FullGrownCallback(CropField cropField){
        if(cropField == currentCropField){
            playerAnimator.StopWaterAnimation();
        }
    }

    void SelectedToolCallback(PlayerSelectTool.Tool selectedTool){
        if(!playerSelectTool.CanWater())
            playerAnimator.StopWaterAnimation();
    }

    void WaterCollidedCallback(Vector3[] waterPosition){
        if(currentCropField == null)
            return;
        currentCropField.WaterCollidedCallback(waterPosition); 
    }

    private void OnTriggerEnter(Collider other){
        if(other.CompareTag("CropField")){
            currentCropField = other.GetComponent<CropField>();
            EnteredField(currentCropField);
        }
    }

    private void EnteredField(CropField cropField){
        if(playerSelectTool.CanWater() && cropField.isSown()){
            playerAnimator.WaterAnimation();
        }
    }

    private void OnTriggerStay(Collider other){
        if(other.CompareTag("CropField")  && other.GetComponent<CropField>().isSown()){
            currentCropField = other.GetComponent<CropField>();
            EnteredField(currentCropField);
        }
    }

    private void OnTriggerExit(Collider other){
        if(other.CompareTag("CropField")){
            playerAnimator.StopWaterAnimation();
            currentCropField = null;
        }
    }
}
