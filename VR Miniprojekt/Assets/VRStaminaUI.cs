using UnityEngine;
using UnityEngine.UI;

public class VRStaminaUI : MonoBehaviour
{
    [Header("Stamina Settings")]
    [SerializeField] private float maxStamina = 100f; 
    [SerializeField] private float currentStamina = 100f; 

    [Header("UI Components")]
    [SerializeField] private Slider staminaSlider; 
    [SerializeField] private GameObject warningUI; 

    [Header("Warning Settings")]
    [SerializeField] private float warningThreshold = 20f; 

    void Start()
    {
       
        if (staminaSlider != null)
        {
            staminaSlider.maxValue = maxStamina;
            staminaSlider.value = currentStamina;
        }

        if (warningUI != null)
            warningUI.SetActive(false);
    }

    void Update()
    {
        // Update the slider value
        if (staminaSlider != null)
            staminaSlider.value = currentStamina;

        
        if (currentStamina <= warningThreshold && warningUI != null)
        {
            if (!warningUI.activeSelf)
                warningUI.SetActive(true);
        }
        else if (currentStamina > warningThreshold && warningUI != null)
        {
            if (warningUI.activeSelf)
                warningUI.SetActive(false);
        }
    }

    
    public void UpdateStamina(float newStamina)
    {
        currentStamina = Mathf.Clamp(newStamina, 0, maxStamina);
    }
}
