using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{
    [SerializeField] private Camera mainCamera;
    [SerializeField] private float interactionDistance = 100f;

    private InteractionSystem currentTarget;

    private void Start()
    {
        if (mainCamera == null)
            mainCamera = Camera.main;
    }

    private void Update()
    {
        if (mainCamera == null)
            return;

        if (Input.GetMouseButton(1))
        {
            SetCurrentTarget(null);
            return;
        }

        CheckMouseTarget();

        if (Input.GetKeyDown(KeyCode.E) && currentTarget != null)
        {
            currentTarget.Interact();
        }
    }

    private void CheckMouseTarget()
    {
        Ray ray =
            mainCamera.ScreenPointToRay(Input.mousePosition);

        Debug.DrawRay(
            ray.origin,
            ray.direction * interactionDistance,
            Color.red
        );

        if (Physics.Raycast(
            ray,
            out RaycastHit hit,
            interactionDistance
        ))
        {
            InteractionSystem newTarget =
                hit.collider.GetComponentInParent<InteractionSystem>();

            SetCurrentTarget(newTarget);
        }
        else
        {
            SetCurrentTarget(null);
        }
    }

    private void SetCurrentTarget(InteractionSystem newTarget)
    {
        if (newTarget == currentTarget)
            return;

        if (currentTarget != null)
            currentTarget.HideUI();

        currentTarget = newTarget;

        if (currentTarget != null)
            currentTarget.ShowUI();
    }
}