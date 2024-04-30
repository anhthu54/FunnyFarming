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

    public static Action<CropField> onFullySownField;
    
    void Start(){
        state = FieldState.Empty;
        StoreTile();
    }
    private void StoreTile(){
        for(int i =0; i<tilesParent.childCount;i++){
            cropTiles.Add(tilesParent.GetChild(i).GetComponent<CropTile>());
        }
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

    private void Sow(CropTile cropTile){
        cropTile.Sow(cropData);
        SownTile++;
        if(SownTile == cropTiles.Count){
            FieldFullySown();
        }
    }

    private void FieldFullySown(){
        state = FieldState.Sown;
        onFullySownField?.Invoke(this);
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

    public bool isEmpty(){
        return state == FieldState.Empty;
    }
}
