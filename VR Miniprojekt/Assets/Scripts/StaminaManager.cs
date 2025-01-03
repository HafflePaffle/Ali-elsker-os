using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class StaminaManager : MonoBehaviour
{
    public float maxStamina = 100;
    public float currentStamina;
    private bool gripping;
    private bool depleted = false;
    [SerializeField] private float staminaLoss;
    [SerializeField] private float staminaRecover;
    [SerializeField] private float cooldown = 1;
    private XRDirectInteractor interactor;
    private float intensity;
    public VRStaminaUI staminaUI;

    void Start()
    {
        currentStamina = maxStamina;
        interactor = GetComponent<XRDirectInteractor>();
    }

    void LateUpdate()
    {
        if(!depleted)
        {
            if (gripping)
            {
                bool canGrip = currentStamina > 0;
                if (canGrip)
                {
                    currentStamina -= staminaLoss * Time.deltaTime;
                    TriggerHaptic();
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
                    currentStamina += staminaRecover * Time.deltaTime;
                }
                else
                {
                    currentStamina = maxStamina;
                }
            }
        }

        {
            if (staminaUI != null)
                staminaUI.UpdateStamina(currentStamina);
        }

    }

    private void ReleaseGrip()
    {
        gripping = false;
        depleted = true;
        Physics.IgnoreLayerCollision(8,6, true);
        interactor.enabled = false;
        StartCoroutine(Cooldown());

    }

    public void Grip()
    {
        gripping = true;
    }

    public void Ungrip()
    {
        gripping = false;
    }

    private void TriggerHaptic()
    {
        intensity = 1 / currentStamina;
        interactor.SendHapticImpulse(intensity, 0);
    }

    IEnumerator Cooldown()
    {
        yield return new WaitForSeconds(cooldown);
        depleted = false;
        Physics.IgnoreLayerCollision(8, 6, false);
        interactor.enabled = true;
    }

     


  
}
