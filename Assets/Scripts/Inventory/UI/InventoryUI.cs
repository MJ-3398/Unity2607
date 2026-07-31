using UnityEngine;

public class InventoryUI : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    [SerializeField] private Inventory inventory;
    [SerializeField] private Transform Container;
    [SerializeField] private GameObject ingredientSlotPrefab;

    [SerializeField] private int slotCount = 80;

    void Start()
    {
        CreateSlots();
    }

    void CreateSlots()
    {
        for (int i = 0; i < slotCount; i++)
        {
            GameObject slot = Instantiate(ingredientSlotPrefab, Container);

            InventorySlotUI ui = slot.GetComponent<InventorySlotUI>();

            if (i < inventory.items.Count)
            {
                ui.SetItem(
                            inventory.items[i].item,
                            inventory.items[i].amount
                          );
            }
            else
            {
                ui.Clear();
            }
        }
    }
}
