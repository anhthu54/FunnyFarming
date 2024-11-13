using System.Collections.Generic;
using UnityEngine;

public class Inventory
{ 
    [SerializeField] private List<InventoryItem> items = new List<InventoryItem>();

    public InventoryItem[] GetInventoryItems()
    {
        return items.ToArray();
    }
    public void CropHarvestedCallback(CropType cropType)
    {
        var cropFound = false;
        foreach (var i in items)
        {
            if (i._cropType == cropType)
            {
                i._amount++;
                cropFound = true;
                break;
            }
        }
        if(cropFound)
            return;
        items.Add(new InventoryItem(cropType,1));
    }
}

