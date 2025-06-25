using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Staycamera : MonoBehaviour
{
    private Camera cam;
    private Vector3 clampedposition;
    // Start is called before the first frame update
    void Start()
    {
        cam=Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 Viewportpos=cam.WorldToViewportPoint(transform.position);

        Viewportpos.x = Mathf.Clamp01(Viewportpos.x);
                Viewportpos.y = Mathf.Clamp01(Viewportpos.y);

        Vector3 clampedworldPos =cam.ViewportToWorldPoint(Viewportpos);
        transform.position = clampedworldPos;
    }
}
