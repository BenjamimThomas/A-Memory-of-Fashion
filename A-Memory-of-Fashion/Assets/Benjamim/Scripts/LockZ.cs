using UnityEngine;

public class LockZ : MonoBehaviour
{
    void LateUpdate()
    {
        Vector3 p = transform.localPosition;
        p.z = 0;
        transform.localPosition = p;
    }
}
