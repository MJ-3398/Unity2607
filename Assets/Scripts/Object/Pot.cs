using UnityEngine;

public class Pot : InteractionSystem
{
    [SerializeField] private GameObject CraftPotion;
    public override void Interact()
    {
        HideUI();
        CraftPotion.SetActive(true);
    }
}
