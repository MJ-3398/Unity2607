using UnityEngine;

public class Pot : InteractionSystem
{
    [SerializeField] private GameObject interactionUI;

    public void ShowUI()
    {
        interactionUI.SetActive(true);
    }

    public void HideUI()
    {
        interactionUI.SetActive(false);
    }

    public override void Interact()
    {
        Debug.Log("포션 제작창 열기");
    }
}
