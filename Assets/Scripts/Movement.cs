using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] float mainThrust = 100f;
    Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        ProcessThrust();
        ProcessHorizontalTrhust();
    }

    void ProcessThrust()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            ApplyThrust(Vector3.up);
        }
    }

    void ProcessHorizontalTrhust()
    {
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            ApplyThrust(Vector3.left);
        }

        else if (Input.GetKey(KeyCode.RightArrow))
        {
            ApplyThrust(Vector3.right);
        }
    }

    void ApplyThrust(Vector3 direction)
    {
        rb.AddRelativeForce(direction * mainThrust * Time.deltaTime);
    }
}
