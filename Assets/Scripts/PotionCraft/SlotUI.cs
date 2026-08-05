using NUnit.Framework.Interfaces;
using UnityEngine;
using UnityEngine.UI;
public class SlotUI : MonoBehaviour
{
    private Image icon;

    public Item Item { get; private set; }

    private void Awake()
    {
        icon = GetComponent<Image>();
    }
    public void SetItem(Item item)
    {
        Item = item;
        icon.enabled = true;
        icon.sprite = item.icon;
    }

    public void Clear()
    {
        Item = null;
        icon.sprite = null;
        icon.enabled = false;
    }

    public bool IsEmpty()
    {
        return Item == null;
    }
}
