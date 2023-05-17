using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform ballTransform;
    public float smoothSpeed = 0.5f;

    private void LateUpdate()
    {
        if (ballTransform != null)
        {
            Vector3 targetPosition = transform.position;
            targetPosition.y = ballTransform.position.y;
            transform.position = Vector3.Lerp(transform.position, targetPosition, smoothSpeed * Time.deltaTime);
        }
    }
}
