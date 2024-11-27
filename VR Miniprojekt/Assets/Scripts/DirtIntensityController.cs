using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

public class DirtIntensityController : MonoBehaviour
{
    public StaminaManager staminaManager1;

   
    public StaminaManager staminaManager2;

    [Header("Post-Processing")]
    public Volume globalVolume; 
    private Vignette vignette;

    [Header("vignette settiongs")]
    public float maxVignette = 0.8f;
    void Start()
    {
        if (globalVolume == null)
        {
            Debug.LogError("Global Volume is not assigned!");
            return;
        }

        // Try to get the Vignette effect from the global volume
        if (globalVolume.profile.TryGet<Vignette>(out vignette))
        {
            Debug.Log("Vignette effect found in the global volume.");
        }
        else
        {
            Debug.LogError("No Vignette effect found in the global volume! Please add it.");
        }
    }

    void Update()
    {
        if (staminaManager1 == null || staminaManager2 == null || vignette == null)
            return;

        // Get the stamina values from both stamina managers
        float stamina1 = staminaManager1.currentStamina / staminaManager1.maxStamina; // Normalize [0-1]
        float stamina2 = staminaManager2.currentStamina / staminaManager2.maxStamina; // Normalize [0-1]

        // Find the lowest stamina between the two managers
        float lowestStamina = Mathf.Min(stamina1, stamina2);

        // Map the lowest stamina to the vignette intensity range
        float vignetteIntensity = Mathf.Lerp(maxVignette, 0, lowestStamina); // High vignette when low stamina

        // Apply the vignette intensity
        vignette.intensity.overrideState = true;
        vignette.intensity.value = vignetteIntensity;
    }
}

