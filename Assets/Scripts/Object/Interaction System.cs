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
        
        if (interactionUI != null)
            interactionUI.SetActive(true);
    }

    public virtual void HideUI()
    {
        if (interactionUI != null)
            interactionUI.SetActive(false);
    }
}
