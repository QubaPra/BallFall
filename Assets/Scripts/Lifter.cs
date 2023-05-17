using UnityEngine;

public class Lifter : MonoBehaviour
{
    public float speed = 1.0f;
    public float startPosY = -16f;
    public float endPosY = -13f;

    private float targetPosY;
    private bool movingForward = true;

    private void Start()
    {
        targetPosY = endPosY;
    }

    private void Update()
    {
        float step = speed * Time.deltaTime;

        // Move towards the target position
        transform.position = Vector3.MoveTowards(transform.position, new Vector3(transform.position.x, targetPosY, transform.position.z), step);

        // Check if the target position is reached
        if (transform.position.y == targetPosY)
        {
            // Change direction
            if (movingForward)
            {
                targetPosY = startPosY;
            }
            else
            {
                targetPosY = endPosY;
            }

            // Toggle moving direction
            movingForward = !movingForward;
        }
    }
}
