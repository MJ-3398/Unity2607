using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class InventorySlotUI : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    [SerializeField] private Image icon;
    [SerializeField] private TMP_Text count;

    public void SetItem(Item item, int amount)
    {
        icon.sprite = item.icon;
        icon.enabled = true;

        count.text = amount.ToString();
    }

    public void Clear()
    {
        icon.sprite = null;
        icon.enabled = false;

        count.text = "";
    }
}
