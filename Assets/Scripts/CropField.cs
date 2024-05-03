using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Analytics;

public class CropField : MonoBehaviour
{
    [SerializeField] private Transform tilesParent;
    private List<CropTile> cropTiles = new List<CropTile>();

    [SerializeField] private CropData cropData;
    private FieldState state;
    private int SownTile;
    private int WateredTile;

    public static Action<CropField> onFullySownField;
    public static Action<CropField> onFullyWateredField;
    
    void Start(){
        state = FieldState.Empty;
        StoreTile();
    }
    private void StoreTile(){
        for(int i =0; i<tilesParent.childCount;i++){
            cropTiles.Add(tilesParent.GetChild(i).GetComponent<CropTile>());
        }
    }
     private CropTile GetClosetCropTile(Vector3 position){
        float minDistance = 20;
        int idCloset = -1;
        for(int i =0;i< cropTiles.Count;i++){
            float distance = Vector3.Distance(cropTiles[i].transform.position,position);
            if(distance<minDistance){
                minDistance = distance;
                idCloset = i;
            }   
        }
        if(idCloset==-1)
            return null;
        return cropTiles[idCloset];
    }
    public void SeedsCollidedCallback(Vector3[] seedPositions){
        for(int i=0;i<seedPositions.Length;i++){
            CropTile closestCroptile = GetClosetCropTile(seedPositions[i]); 
            if(closestCroptile == null){
                continue;
            }
            if(!closestCroptile.isEmpty()){
                continue;
            }
            Sow(closestCroptile);
        }
      
    }

    public void WaterCollidedCallback(Vector3[] waterPosition){
        for(int i =0;i<waterPosition.Length;i++){
            CropTile closetCroptile = GetClosetCropTile(waterPosition[i]);
            if(closetCroptile == null)
                continue;
            if(!closetCroptile.isSown()){
                continue;
            }
            Water(closetCroptile);
        }
    }
    private void Sow(CropTile cropTile){
        cropTile.Sow(cropData);
        SownTile++;
        if(SownTile == cropTiles.Count){
            FieldFullySown();
        }
    }

    private void Water(CropTile cropTile){
        cropTile.Water();
        WateredTile++;
        if(WateredTile == cropTiles.Count){
            FieldFullyWatered();
        }

    }

    private void FieldFullySown(){
        state = FieldState.Sown;
        onFullySownField?.Invoke(this);
    }

    private void FieldFullyWatered(){
        state = FieldState.Watered;
        onFullyWateredField?.Invoke(this);
    }
   

    public bool isEmpty(){
        return state == FieldState.Empty;
    }

    public bool isSown(){
        return state == FieldState.Sown;
    }
}
