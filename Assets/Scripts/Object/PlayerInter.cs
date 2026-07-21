using UnityEngine;
using TMPro;

public class PlayerInteraction : MonoBehaviour
{
    public Camera mainCamera;

    public float interactDistance = 3f;

    public GameObject interactionUI;

    public TextMeshProUGUI interactionText;

    private InteractionSystem currentInteractable;

    void Update()
    {
        Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);

        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, interactDistance))
        {
            InteractionSystem interactable = hit.collider.GetComponent<InteractionSystem>();

            if (interactable != null)
            {
                currentInteractable = interactable;

                interactionUI.SetActive(true);

                interactionText.text = interactable.interationText;

                if (Input.GetMouseButtonDown(0))
                {
                    interactable.Interact();
                }

                return;
            }
        }

        currentInteractable = null;

        interactionUI.SetActive(false);
    }
}