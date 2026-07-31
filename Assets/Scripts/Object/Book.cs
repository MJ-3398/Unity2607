using UnityEngine;

public class Book : InteractionSystem
{
    [SerializeField] private GameObject QuestUI;
    public override void Interact()
    {
        HideUI();
        QuestUI.SetActive(true);
    }
}
