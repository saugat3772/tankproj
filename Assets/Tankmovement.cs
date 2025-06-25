using UnityEngine;

public class Tankmovement : MonoBehaviour
{
    public float speed; // Adjust speed as needed
    public float minStopDistance; // Minimum random stop distance
    public float maxStopDistance; // Maximum random stop distance

    private float stopDistance;
    private Vector3 startPosition;
    private bool stopped = false;

    void Start()
    {
        startPosition = transform.position;
        stopDistance = Random.Range(minStopDistance, maxStopDistance);
    }

    void Update()
    {
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
