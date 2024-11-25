using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StaminaManager : MonoBehaviour
{
    public float maxStamina = 100;
    public float currentStamina;
    private bool gripping;
    [SerializeField] private float staminaLoss;
    [SerializeField] private float staminaRecover;

    void Start()
    {
        currentStamina = maxStamina;
    }

    void LateUpdate()
    {
        if(gripping)
        {
            bool canGrip = currentStamina > 0;
            if (canGrip)
            {
                currentStamina -= staminaLoss;
            }
            else
            {
                currentStamina = 0;
                ReleaseGrip();
            }
        }
        else
        {
            if (currentStamina < maxStamina)
            {
                currentStamina += staminaRecover;
            }
            else
            {
                currentStamina = maxStamina;
            }
        }
    }

    private void ReleaseGrip()
    {
        gripping = false;
    }

    public void Grip()
    {
        gripping = true;
    }
}
