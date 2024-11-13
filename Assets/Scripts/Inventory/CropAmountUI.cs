using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CropAmountUI : MonoBehaviour
{
    [SerializeField] private Image icon;

    [SerializeField] private TextMeshProUGUI amountText;

    public void DisplayCrop(Sprite iconSprite, int amount)
    {
        icon.sprite = iconSprite;
        amountText.text = amount.ToString();
    }

    public void UpdateDisplay(int amount)
    {
        amountText.text = amount.ToString();
    }
}
