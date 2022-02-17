using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] float mainThrust = 100f;
    [SerializeField] AudioClip mainEngine;

    Rigidbody rb;
    AudioSource audioSource;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        ProcessThrust();
    }

    void ProcessThrust()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            ApplyThrust(Vector3.up);
        }
        else if (Input.GetKey(KeyCode.LeftArrow))
        {
            ApplyThrust(Vector3.left);
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            ApplyThrust(Vector3.right);
        }
        else if (audioSource.isPlaying)
        {
            audioSource.Stop();
        }
    }

    void ApplyThrust(Vector3 direction)
    {
        rb.AddRelativeForce(direction * mainThrust * Time.deltaTime);
        if (!audioSource.isPlaying)
        {
            audioSource.PlayOneShot(mainEngine);
        }
    }
}
