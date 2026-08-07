using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class Movement : MonoBehaviour
{
    [Header("Movement")]
    [SerializeField] private float moveSpeed = 5f;
    [SerializeField] private float mouseSensitivity = 150f;

    private CharacterController controller;
    private Transform cameraPivot;
    private float pitch;

    private void Awake()
    {
        controller = GetComponent<CharacterController>();
        cameraPivot = transform.Find("Camera Pivot");

        if (cameraPivot == null)
            Debug.LogError("Camera Pivot을 찾을 수 없습니다.");
    }

    private void Start()
    {
        ReleaseCursor();
    }

    private void Update()
    {
        Move();
        HandleCameraLook();
    }

    private void Move()
    {
        float x = Input.GetAxisRaw("Horizontal");
        float z = Input.GetAxisRaw("Vertical");

        Vector3 direction =
            transform.right * x +
            transform.forward * z;

        direction.Normalize();

        controller.Move(direction * moveSpeed * Time.deltaTime);
    }

    private void HandleCameraLook()
    {
        if (Input.GetMouseButtonDown(1))
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }

        if (Input.GetMouseButton(1))
        {
            Look();
        }

        if (Input.GetMouseButtonUp(1))
        {
            ReleaseCursor();
        }
    }

    private void Look()
    {
        if (cameraPivot == null)
            return;

        float mouseX =
            Input.GetAxis("Mouse X") *
            mouseSensitivity *
            Time.deltaTime;

        float mouseY =
            Input.GetAxis("Mouse Y") *
            mouseSensitivity *
            Time.deltaTime;

        transform.Rotate(Vector3.up * mouseX);

        pitch -= mouseY;
        pitch = Mathf.Clamp(pitch, -85f, 85f);

        cameraPivot.localRotation =
            Quaternion.Euler(pitch, 0f, 0f);
    }

    private void ReleaseCursor()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }
}