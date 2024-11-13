using UnityEngine;
using UnityEngine.Serialization;

[CreateAssetMenu(fileName = "Crop Data", menuName ="Scriptable/Crop data", order  = 0)]
public class CropData : ScriptableObject
{
    public CropType cropType; 
    public Crop cropBabyPrefab;
    public Crop cropGrownPrefab;
    public Sprite cropIcon;
}
