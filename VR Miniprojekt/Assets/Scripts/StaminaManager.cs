using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StaminaManager : MonoBehaviour
{
    public float maxStamina = 100;
    public float currentStamina;
    private bool gripping;
    [SerializeField] private float staminaLoss;

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
    }

    private void ReleaseGrip()
    {

    }
}
