using UnityEngine;

public class Pusher : MonoBehaviour
{
    public float speed = 1.0f;
    public float startPosZ = 2.0f;
    public float endPosZ = 0.0f;

    private float targetPosZ;
    private bool movingForward = true;

    private void Start()
    {
        targetPosZ = endPosZ;
    }

    private void Update()
    {
        float step = speed * Time.deltaTime;

        // Move towards the target position
        transform.position = Vector3.MoveTowards(transform.position, new Vector3(transform.position.x, transform.position.y, targetPosZ), step);

        // Check if the target position is reached
        if (transform.position.z == targetPosZ)
        {
            // Change direction
            if (movingForward)
            {
                targetPosZ = startPosZ;
            }
            else
            {
                targetPosZ = endPosZ;
            }

            // Toggle moving direction
            movingForward = !movingForward;
        }
    }
}
