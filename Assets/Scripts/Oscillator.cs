using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Oscillator : MonoBehaviour
{
    Vector3 startingPosition;
    [SerializeField] Vector3 movementVector;
    [SerializeField] [Range(0, 1)] float movementFactor;
    [SerializeField] float period = 2f;

    // Start is called before the first frame update
    void Start()
    {
        startingPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (period <= Mathf.Epsilon) { return; }
        float cycles = Time.time / period; // current angle in rad

        const float tau = Mathf.PI * 2; // tau == 6.283...
        float rawSinWave = Mathf.Sin(cycles * tau); // obstacle's current offset

        movementFactor = (rawSinWave + 1f) / 2f; // normalized to go from 0 to 1

        Vector3 offset = movementVector * movementFactor;
        //transform.Translate(offset);
        transform.position = startingPosition + offset;
    }
}
