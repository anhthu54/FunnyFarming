using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum FieldState {Empty,Sown,Watered}
public class CropTile : MonoBehaviour
{

    private FieldState state;
    [SerializeField] private Transform cropParent;
    [SerializeField] private Renderer tileRenderer;
    private Crop crop;

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
        
        crop = Instantiate(cropData.cornPrefab,transform.position, Quaternion.identity, cropParent);
    }

    public void Water(){
        state = FieldState.Watered;
        Debug.Log("Watered");
        tileRenderer.material.color = Color.gray;
        crop.GrowUp(2f);
    }

    public bool isEmpty(){
        return state == FieldState.Empty;
    }

    public bool isSown(){
        return state == FieldState.Sown;
    }
}
