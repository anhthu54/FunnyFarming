using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum FieldState {Empty,Sown,Watered}
public class CropTile : MonoBehaviour
{

    private FieldState state;
    [SerializeField] private Transform cropParent;

    // Start is called before the first frame update
    void Start()
    {
        state = FieldState.Empty;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Sow(CropData cropData){
        state = FieldState.Sown;
        
        Crop crop = Instantiate(cropData.cornPrefab,transform.position, Quaternion.identity, cropParent);
    }

    public bool isEmpty(){
        return state == FieldState.Empty;
    }
}
