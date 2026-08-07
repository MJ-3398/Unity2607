using NUnit.Framework.Interfaces;
using UnityEngine;
using UnityEngine.UI;

public class IngredientSlot : MonoBehaviour
{
    [SerializeField] private Image icon;

    public bool IsEmpty => icon.sprite == null;
    public void SetItem(Item item)
    {
        icon.sprite = item.icon;
        icon.enabled = true;
    }

    public void Clear()
    {
        icon.sprite = null;
        icon.enabled = false;
    }
}
