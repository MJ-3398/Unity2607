using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class InventorySlotUI : MonoBehaviour
{
    [SerializeField] private Image icon;
    [SerializeField] private TMP_Text count;

    private Item currentItem;
    private Button button;

    private void Awake()
    {
        button = GetComponent<Button>();

        if (button != null)
        {
            button.onClick.AddListener(OnClick);
        }
        else
        {
            Debug.LogError($"{name}에 Button 컴포넌트가 없습니다.");
        }
    }

    public void SetItem(Item item, int amount)
    {
        currentItem = item;

        icon.sprite = item.icon;
        icon.enabled = true;
        count.text = amount.ToString();

        button.interactable = true;
    }

    public void Clear()
    {
        currentItem = null;

        icon.sprite = null;
        icon.enabled = false;
        count.text = "";

        if (button != null)
        {
            button.interactable = false;
        }
    }

    private void OnClick()
    {
        CraftUI.Instance.AddIngredient(currentItem);
    }
}