using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryListDisplay : MonoBehaviour
{
    [SerializeField] private Transform listTransform;

    [SerializeField] private CropAmountUI cropAmountUIPrefab;

    public void DisplayList(Inventory inventory)
    {
        InventoryItem[] items = inventory.GetInventoryItems();
        foreach (var i in items)
        {
            CropAmountUI cropAmountUI = Instantiate(cropAmountUIPrefab, listTransform);
            var cropIcon = DataManager.instance.GetCropSprite(i._cropType);
            cropAmountUI.DisplayCrop(cropIcon,i._amount);
        }
    }

    public void UpdateList(Inventory inventory)
    {
        InventoryItem[] items = inventory.GetInventoryItems();
        for (int i = 0; i < items.Length; i++)
        {
            CropAmountUI cropAmountUI = listTransform.GetChild(i).GetComponent<CropAmountUI>();
            if (i < listTransform.childCount)
            {
                cropAmountUI.gameObject.SetActive(true);
            }
            else
            {
                cropAmountUI = Instantiate(cropAmountUIPrefab, listTransform);
            }
            var cropIcon = DataManager.instance.GetCropSprite(items[i]._cropType);
            cropAmountUI.DisplayCrop(cropIcon,items[i]._amount);
        }
    }
}
