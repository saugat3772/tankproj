using UnityEngine;

public class bosstank : MonoBehaviour
{
    public float speed; // Adjust speed as needed
    public float minStopDistance; // Minimum random stop distance
    public float maxStopDistance; // Maximum random stop distance
    public float delayBeforeMove = 2f; // Time in seconds before tank starts moving

    private float stopDistance;
    private Vector3 startPosition;
    private bool stopped = false;
    private float timer = 0f;
    private bool canMove = false;

    void Start()
    {
        startPosition = transform.position;
        stopDistance = Random.Range(minStopDistance, maxStopDistance);
        timer = 0f;
        canMove = false;
    }

    void Update()
    {
        if (!canMove)
        {
            timer += Time.deltaTime;
            if (timer >= delayBeforeMove)
            {
                canMove = true;
            }
            else
            {
                return;
            }
        }

        if (!stopped)
        {
            float distanceMoved = startPosition.y - transform.position.y;
            if (distanceMoved < stopDistance)
            {
                float moveAmount = speed * Time.deltaTime;
                // Clamp movement if about to exceed stopDistance
                if (distanceMoved + moveAmount > stopDistance)
                {
                    moveAmount = stopDistance - distanceMoved;
                }
                transform.position -= Vector3.up * moveAmount;
            }
            else
            {
                stopped = true;
            }
        }
    }
}
