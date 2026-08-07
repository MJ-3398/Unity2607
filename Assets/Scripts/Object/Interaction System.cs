using UnityEngine;

public abstract class InteractionSystem : MonoBehaviour
{
    public string interationText = "Interaction";
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    [SerializeField] private GameObject interactionUI;

    public virtual void Interact()
    {
        Debug.Log(gameObject.name + " 상호작용");
    }

    public virtual void ShowUI()
    {
        if (interactionUI == null)
        {
            Debug.LogError(gameObject.name + "의 Interaction UI가 없습니다.");
            return;
        }

        interactionUI.SetActive(true);

        Debug.Log(
            "상호작용 UI 활성화: " +
            interactionUI.name +
            " / 실제 표시 상태: " +
            interactionUI.activeInHierarchy
        );
    }

    public virtual void HideUI()
    {
        if (interactionUI != null)
            interactionUI.SetActive(false);
    }
}
