using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private AudioSource audioSource;
    public GameObject BulletPrefab;
    // Start is called before the first frame update
    void Start()
    {
        audioSource=GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Instantiate(BulletPrefab,transform.position,Quaternion.identity);
            audioSource.Play();
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(0.01f, 0, 0);
        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.Translate(-0.01f, 0, 0);
        }

    }
}
