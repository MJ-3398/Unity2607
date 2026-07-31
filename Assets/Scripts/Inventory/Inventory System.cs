using UnityEngine;

public class InventorySystem : MonoBehaviour
{
    [SerializeField] private GameObject inventoryUI;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            inventoryUI.SetActive(!inventoryUI.activeSelf);
        }
    }
}
