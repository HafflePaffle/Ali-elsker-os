using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class MethodTester : MonoBehaviour
{
    public KeyCode kc;
    public UnityEvent events;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(kc))
        {
            events.Invoke();
        }
    }
}
