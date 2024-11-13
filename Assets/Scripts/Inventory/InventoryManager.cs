using System.IO;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    private Inventory _inventory;
    private InventoryListDisplay _inventoryUI;
    private string dataPath;
    private void Start()
    {
        dataPath = Application.dataPath + "/inventoryData.txt";
        LoadData();
        CropTile.onHarvested += HarvestedCallback;
        
        DisplayInventory();
    }

    private void OnDestroy()
    {
        CropTile.onHarvested -= HarvestedCallback;
    }

    private void DisplayInventory()
    {
        _inventoryUI = GetComponent<InventoryListDisplay>();
        _inventoryUI.DisplayList(_inventory);
    }
    private void HarvestedCallback(CropType cropType)
    {
        _inventory.CropHarvestedCallback(cropType);
        _inventoryUI.UpdateList(_inventory);
        SaveData();
    }

    private void LoadData()
    {
        string data = "";
        if (File.Exists(dataPath))
        {
            data = File.ReadAllText(dataPath);
            _inventory = JsonUtility.FromJson<Inventory>(data);
            if (_inventory == null)
            {
                _inventory = new Inventory();
            }
        }
        else
        {
            File.Create(dataPath);
            _inventory = new Inventory();
        }
    }

    private void SaveData()
    {
        string data = JsonUtility.ToJson(_inventory);
        File.WriteAllText(dataPath,data);
    }
}
