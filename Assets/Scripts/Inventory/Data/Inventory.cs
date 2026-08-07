using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public List<InventorySlot> items = new List<InventorySlot>();
    public bool RemoveItem(Item item, int amount)
    {
        InventorySlot targetSlot = items.Find(slot => slot.item.ItemName == item.ItemName);
        if (targetSlot == null)
        {
            return false;
        }

        if (targetSlot.amount < amount)
        {
            return false;
        }

        targetSlot.amount -= amount;

        if (targetSlot.amount <= 0)
        {
            items.Remove(targetSlot);
        }

        return true;
    }

    public void AddItem(Item item, int amount)
    {
        InventorySlot targetSlot = items.Find(slot => slot.item.ItemName == item.ItemName);

        if (targetSlot != null)
        {
            targetSlot.amount += amount;
            return;
        }

        InventorySlot newSlot = new InventorySlot();

        newSlot.item = item;
        newSlot.amount = amount;

        items.Add(newSlot);
    }
}