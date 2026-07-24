using UnityEngine;
using TMPro;

public class PlayerInteraction : MonoBehaviour
{
    [SerializeField] private Camera mainCamera;
    [SerializeField] private float interactionDistance = 10f;

    private InteractionSystem currentTarget;
    void Update()
    {
            Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out RaycastHit hit, interactionDistance))
        {
            InteractionSystem interactable = hit.collider.GetComponentInParent<InteractionSystem>();
        
        
            if (interactable != currentTarget)
            {
                if (currentTarget != null)
                {
                    currentTarget.HideUI();
                    currentTarget = null;
                }
                currentTarget = interactable;
        
                if (currentTarget != null)
                {
                 currentTarget.ShowUI();
                }
            }
        }


        if (Input.GetMouseButtonDown(0))
        {
            if (currentTarget != null)
            {
                currentTarget.Interact();
            }
        }
    }
}