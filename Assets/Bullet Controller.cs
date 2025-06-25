using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        transform.Translate(0, 0.2f, 0);
        if (transform.position.y > 5)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D coll)
    {
        // Check if the collided object has a BulletHitCounter component
        BulletHitCounter hitCounter = coll.GetComponent<BulletHitCounter>();
        if (hitCounter != null)
        {
            hitCounter.RegisterHit();
        }
        Destroy(gameObject);
    }
}

// Attach this script to any GameObject you want to be destroyed after a certain number of bullet hits
public class BulletHitCounter : MonoBehaviour
{
    public int hitsToDestroy = 3;
    private int currentHits = 0;

    public void RegisterHit()
    {
        currentHits++;
        if (currentHits >= hitsToDestroy)
        {
            Destroy(gameObject);
        }
    }
}
