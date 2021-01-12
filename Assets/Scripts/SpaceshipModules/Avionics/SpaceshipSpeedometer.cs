using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class SpaceshipSpeedometer : MonoBehaviour
{
    private Rigidbody rb;

    public float currentSpeed;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        currentSpeed = rb.velocity.x + rb.velocity.y + rb.velocity.z;
    }
}
