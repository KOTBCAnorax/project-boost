using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] float mainThrust = 100f;
    [SerializeField] AudioClip mainEngine;
    [SerializeField] ParticleSystem LeftBoosterParticle;
    [SerializeField] ParticleSystem MainBoosterParticle;
    [SerializeField] ParticleSystem RightBoosterParticle;

    Rigidbody rb;
    AudioSource audioSource;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        ProcessInput();
    }

    void ProcessInput()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            ApplyThrust(Vector3.up);
            PlayThrustingEffect(MainBoosterParticle);
        }
        else if (Input.GetKeyUp(KeyCode.Space))
        {
            StopThrustingEffect(MainBoosterParticle);
        }

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            ApplyThrust(Vector3.left);
            PlayThrustingEffect(RightBoosterParticle);
        }
        else if (Input.GetKeyUp(KeyCode.LeftArrow))
        {
            StopThrustingEffect(RightBoosterParticle);
        }

        if (Input.GetKey(KeyCode.RightArrow))
        {
            ApplyThrust(Vector3.right);
            PlayThrustingEffect(LeftBoosterParticle);
        }
        else if (Input.GetKeyUp(KeyCode.RightArrow))
        {
            StopThrustingEffect(LeftBoosterParticle);
        }

        if (!Input.anyKey)
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

    void PlayThrustingEffect(ParticleSystem particle)
    {
        if (!particle.isPlaying)
        {
            particle.Play();
        }
    }

    void StopThrustingEffect(ParticleSystem particle)
    {
        if (particle.isPlaying)
        {
            particle.Stop();
        }
    }
}
