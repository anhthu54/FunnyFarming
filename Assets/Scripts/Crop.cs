using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crop : MonoBehaviour
{
    [SerializeField] private Transform cropRenderer;
    public void GrowUp(float a){
        cropRenderer.localScale *= a;
    }
}
