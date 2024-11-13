using System;
using UnityEngine;

public class DataManager : MonoBehaviour
{
    public static DataManager instance;
    [SerializeField] private CropData[] _cropData;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public Sprite GetCropSprite(CropType cropType)
    {
        foreach (var crop in _cropData)
        {
            if (crop.cropType == cropType)
            {
                return crop.cropIcon;
            }
        }
        return null;
    }
}
