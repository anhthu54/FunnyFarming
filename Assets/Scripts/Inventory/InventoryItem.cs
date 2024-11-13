public enum CropType
{
    Corn,
    Tomato,
}
[System.Serializable]
public class InventoryItem
{
    public CropType _cropType;
    public int _amount;

    public int Amount{
        get {
            return _amount;
        }
        set
        {
            _amount = value;
        }
    }
    
    public InventoryItem(CropType cropType, int amount)
    {
        this._cropType = cropType;
        this._amount = amount;
    }
}