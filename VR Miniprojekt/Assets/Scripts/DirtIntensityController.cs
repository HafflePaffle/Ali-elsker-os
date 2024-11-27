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
    void Start()
    {
        if (globalVolume == null)
        {
            Debug.LogError("Global Volume is not assigned!");
            return;
        }

       
        if (globalVolume.profile.TryGet<Vignette>(out vignette))
        {
            Debug.Log("Bloom effect found in the global volume.");
        }
        else
        {
            Debug.LogError("No Bloom effect found in the global volume! Please add it.");
        }
    }

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

