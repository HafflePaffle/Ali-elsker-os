using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

public class DirtIntensityController : MonoBehaviour
{
    [Header("Stamina Reference")]
    public StaminaManager staminaManager; 

    [Header("Post-Processing")]
    public Volume globalVolume; 
    private Vignette vignette;

    [Header("vignette settiongs")]
    public float maxVignette = 100f; 
  

    void Update()
    {
        if (staminaManager == null || vignette == null)
            return;

        
        float normalizedStamina = staminaManager.currentStamina / staminaManager.maxStamina; 
        float dirtIntensity = Mathf.Lerp(maxVignette, 0, normalizedStamina); 

      
        vignette.intensity.overrideState = true; 
        vignette.intensity.value = dirtIntensity;
    }
}

