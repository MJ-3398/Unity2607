using UnityEngine;
using System.Collections.Generic;
public class CraftUI : MonoBehaviour
{
    [SerializeField] private Inventory inventory;
    [SerializeField] private Transform container;
    [SerializeField] private GameObject ingredientSlotPrefab;

    [SerializeField] private SlotUI[] craftSlots;
    [SerializeField] private Recipe[] recipes;
    public static CraftUI Instance { get; private set; }

    private void Awake()
    {
        Instance = this;
    }

    private void OnEnable()
    {
        Refresh();
    }

    private void OnDestroy()
    {
        if (Instance == this)
            Instance = null;
    }

    private void Refresh()
    {
        foreach (Transform child in container)
        {
            Destroy(child.gameObject);
        }

        foreach (InventorySlot inventorySlot in inventory.items)
        {
            GameObject slotObject =
                Instantiate(ingredientSlotPrefab, container);

            InventorySlotUI slotUI =
                slotObject.GetComponent<InventorySlotUI>();

            if (slotUI == null)
            {
                Debug.LogError(
                    $"{ingredientSlotPrefab.name} 프리팹에 InventorySlotUI가 없습니다."
                );

                continue;
            }

            slotUI.SetItem(inventorySlot.item, inventorySlot.amount);
        }
    }

    public void AddIngredient(Item item)
    {
        foreach (SlotUI craftSlot in craftSlots)
        {
            if (craftSlot.IsEmpty())
            {
                bool removed = inventory.RemoveItem(item, 1);

                craftSlot.SetItem(item);
                Refresh();

                return;
            }
        }
    }
    public void RemoveIngredient(SlotUI craftSlot)
    {
        if (craftSlot == null)
        {
            return;
        }

        if (craftSlot.IsEmpty())
        {
            return;
        }

        Item item = craftSlot.Item;

        craftSlot.Clear();
        inventory.AddItem(item, 1);

        Refresh();
    }

    public void Craft()
    {
        List<string> selectedIngredients = new List<string>();

        foreach (SlotUI craftSlot in craftSlots)
        {
            selectedIngredients.Add(craftSlot.Item.ItemName);
        }

        foreach (Recipe recipe in recipes)
        {
            if (IsRecipeMatch(selectedIngredients, recipe))
            {
                CompleteCraft(recipe);
                return;
            }
        }

    }
}