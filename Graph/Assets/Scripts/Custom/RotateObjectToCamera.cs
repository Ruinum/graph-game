using UnityEngine;

public class RotateObjectToCamera : MonoBehaviour
{
    private void Update()
    {
        if (!Camera.main) return;

        transform.LookAt(Camera.main.transform);
    }
}
