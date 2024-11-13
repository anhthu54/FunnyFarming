using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering;
using UnityEngine;
using UnityEngine.UI;

public class PlayerSelectTool : MonoBehaviour
{
    public enum Tool {None, Sow, Water, Harvest}
    private Tool selectedTool;
    public Action<Tool> onSelectedTool;

    [Header(" Elements ")]
    [SerializeField]
    private Image[] toolImage;

    [Header(" Setting ")]
    [SerializeField]
    private Color selectedColor; 
    void Start()
    {
        SelectTool(0);
    }
    
    public void SelectTool(int toolIndex){
        selectedTool = (Tool)toolIndex;
        for(int i = 0;i<toolImage.Length;i++)
            toolImage[i].color = i == toolIndex ? selectedColor : Color.white;
        onSelectedTool?.Invoke(selectedTool);
    }
    
    public bool CanSow(){
        return selectedTool == Tool.Sow;
    }

    public bool CanWater(){
        return selectedTool == Tool.Water;
    }

    public bool CanHarvest(){
        return selectedTool == Tool.Harvest;
    }
}
