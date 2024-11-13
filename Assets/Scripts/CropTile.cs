using System;
using System.Collections;
using Unity.Mathematics;
using UnityEngine;

public enum FieldState {Empty,Sown,Watered,Grown}
public class CropTile : MonoBehaviour
{

    private FieldState state;
    [SerializeField] private Transform cropParent;
    [SerializeField] private Renderer tileRenderer;
    private Crop _crop;
    private CropData _cropData;

    public static Action<CropType> onHarvested;
    void Start()
    {
        state = FieldState.Empty;
    }


    public void Sow(CropData cropData){
        state = FieldState.Sown;
        
        _crop = Instantiate(cropData.cropBabyPrefab,transform.position, Quaternion.identity, cropParent);
        _cropData = cropData;
    }
    
    public void Water(){
        state = FieldState.Watered;
        LeanTween.color(tileRenderer.gameObject, Color.gray, 1f).setEase(LeanTweenType.easeOutBack);
        _crop.GrowUp(2f);
        StartCoroutine(GrowUp());
    }

    private IEnumerator GrowUp()
    {
        yield return new WaitForSeconds(1);
        _crop.ScaleDown();
        _crop = Instantiate(_cropData.cropGrownPrefab, transform.position, quaternion.identity, cropParent);
        _crop.GrowUp(2f);
        state = FieldState.Grown;
    }
    

    public void Harvest()
    {
        state = FieldState.Empty;
        LeanTween.color(tileRenderer.gameObject, Color.white, 0.5f);
        _crop.ScaleDown();
        _crop.PlayEffect();
        onHarvested?.Invoke(_cropData.cropType);
    }

    public bool isEmpty(){
        return state == FieldState.Empty;
    }

    public bool isSown(){
        return state == FieldState.Sown;
    }

    public bool isGrown()
    {
        return state == FieldState.Grown;
    }
}
