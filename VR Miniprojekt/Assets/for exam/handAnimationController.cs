using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


public class handAnimationController : MonoBehaviour
{

    public InputActionProperty pinchAnimation;
    public InputActionProperty grabAnimation;

    public Animator handAnimation;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float pinchValue = pinchAnimation.action.ReadValue<float>();
        Debug.Log("pinch value" + pinchValue);
        handAnimation.SetFloat("Pinch", pinchValue);

        float grabValue = grabAnimation.action.ReadValue<float>();
        Debug.Log("grab value" + grabValue);
        handAnimation.SetFloat("Grab", grabValue);

    }
}
