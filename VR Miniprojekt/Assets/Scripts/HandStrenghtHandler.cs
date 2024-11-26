using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandStrenghtHandler : MonoBehaviour
{
    private Vector3 prevPosition;
    private Rigidbody rb;
    public Transform handTarget;
    private void Start()
    {
        prevPosition = transform.position;
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        Vector3 handVel = (handTarget.localPosition - prevPosition) / Time.fixedDeltaTime;
        float drag = 1/handVel.magnitude + 0.01f;

        drag = drag >= 1 ? 1 : drag;
        drag = drag <= 0.3f ? 0.3f : drag;
        rb.AddForce(-rb.velocity * Mathf.Pow(drag, 2));

        prevPosition = transform.position;
    }
}
