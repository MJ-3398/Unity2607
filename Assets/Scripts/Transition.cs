using UnityEngine;

public class Transition : MonoBehaviour
{
    public Transform playerPoint;
    public Transform cameraPoint;

    public void Move()
    {
        player.transform.position = playerPoint.position;

        Camera.main.transform.position = cameraPoint.position;
        Camera.main.transform.rotation = cameraPoint.rotation;
    }
}
