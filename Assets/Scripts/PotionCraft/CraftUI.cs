using NUnit.Framework.Interfaces;
using UnityEngine;

public class CraftUI : MonoBehaviour
{
    [SerializeField] private Inventory inventory;
    [SerializeField] private Transform Container;
    [SerializeField] private GameObject IngredientSlot;
    [SerializeField] private SlotUI[] craftSlots;
    void OnEnable()
    {
        Refresh();
    }

    void Refresh()
    {
        foreach (Transform child in Container)
        {
            Destroy(child.gameObject);
        }

        foreach (InventorySlot slot in inventory.items)
        {
            GameObject obj = Instantiate(IngredientSlot, Container);

            InventorySlotUI ui = obj.GetComponent<InventorySlotUI>();

            ui.SetItem(slot.item, slot.amount);
        }
    }
    public void AddIngredient(Item item)
    {
        foreach (SlotUI slot in craftSlots)
        {
            if (slot.IsEmpty())
            {
                slot.SetItem(item);
                return;
            }
        }
    }

}
