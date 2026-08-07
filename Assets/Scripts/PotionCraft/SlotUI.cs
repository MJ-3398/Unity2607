using UnityEngine;
using UnityEngine.UI;
public class SlotUI : MonoBehaviour
{
    [SerializeField] private Image icon;
    public Item Item { get; private set; }

    private Button button;

    private void Awake()
    {
        button = GetComponent<Button>();

        if (icon == null)
        {
            icon = GetComponent<Image>();
        }
        button.onClick.AddListener(OnClick);
    }

    public void SetItem(Item item)
    {
        Item = item;

        icon.sprite = item.icon;
        icon.enabled = true;

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

    private void OnClick()
    {
        if (IsEmpty())
        {
            return;
        }

        CraftUI.Instance.RemoveIngredient(this);
    }
}