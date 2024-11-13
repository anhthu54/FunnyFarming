using UnityEditor.ShaderKeywordFilter;
using UnityEngine;

public class PlayerHarvestAbility : MonoBehaviour
{
    [SerializeField] private Transform _harvestSphere;
    private PlayerAnimator _playerAnimator;
    private PlayerSelectTool _selectTool;

    private CropField _currentCropField;
    private bool canHarvest;
    private void Start()
    {
        _playerAnimator = GetComponent<PlayerAnimator>();
        _selectTool = GetComponent<PlayerSelectTool>();

        CropField.onFullyHarvestedField += OnFullyHarvestedCallback;
        _selectTool.onSelectedTool += SelectedToolCallback;
    }

    private void OnDestroy()
    {
        CropField.onFullyHarvestedField -= OnFullyHarvestedCallback;
        _selectTool.onSelectedTool -= SelectedToolCallback;

    }

    private void OnFullyHarvestedCallback(CropField cropField)
    {
        if (cropField == _currentCropField)
        {
            _playerAnimator.StopHarvestAnimation();
        }
    }
    private void SelectedToolCallback(PlayerSelectTool.Tool selectedTool)
    {
        if(!_selectTool.CanHarvest())
            _playerAnimator.StopHarvestAnimation();
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("CropField"))
        {
            _currentCropField = other.GetComponent<CropField>();
            EnterField(_currentCropField);
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("CropField"))
        {
            _currentCropField = other.GetComponent<CropField>();
            EnterField(_currentCropField);
        }
    }
    private void EnterField(CropField cropField)
    {
        
        if (_selectTool.CanHarvest() && cropField.isGrown())
        {
            if (_currentCropField == null)
            {
                _currentCropField = cropField;
            }
            _playerAnimator.HarvestAnimation();
        }

        if (canHarvest)
        {
            cropField.Harvest(_harvestSphere);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("CropField"))
        {
            _playerAnimator.StopHarvestAnimation();
            _currentCropField = null;
        }
    }

    public void StartHarvestCallback()
    {
        canHarvest = true;
    }

    public void StopHarvestCallback()
    {
        canHarvest = false;
    }
}
