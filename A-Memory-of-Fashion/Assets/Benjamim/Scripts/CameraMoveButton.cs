using UnityEngine;

public class CameraMoveButton : MonoBehaviour
{
    public Camera mainCamera;
    public Transform targetPosition;
    public float speed = 5f; 
    private bool moveCamera = false;

    void Update()
    {
        if (moveCamera && mainCamera != null && targetPosition != null)
        {
            mainCamera.transform.position = Vector3.Lerp(
                mainCamera.transform.position,
                new Vector3(targetPosition.position.x, targetPosition.position.y, mainCamera.transform.position.z),
                Time.deltaTime * speed
            );
            if (Vector3.Distance(mainCamera.transform.position, targetPosition.position) < 0.05f)
            {
                moveCamera = false;
            }
        }
    }
    public void MoveCamera()
    {
        moveCamera = true;
    }
}
