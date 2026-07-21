using UnityEngine;

public class Pot : InteractionSystem
{
    public GameObject UI;

    public override void Interact()
    {
        UI.SetActive(true);
    }
}
