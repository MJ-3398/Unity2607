using UnityEngine;

public class Pot : InteractionSystem
{
    [SerializeField] private GameObject CraftPotion;
    public override void Interact()
    {
        CraftPotion.SetActive(true);
    }
}
