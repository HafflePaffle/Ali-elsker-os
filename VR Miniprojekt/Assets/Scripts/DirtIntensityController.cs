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

        
        float stamina1 = staminaManager1.currentStamina / staminaManager1.maxStamina; 
        float stamina2 = staminaManager2.currentStamina / staminaManager2.maxStamina; 

        // Find the lowest stamina between the two managers
        float lowestStamina = Mathf.Min(stamina1, stamina2);

        
        float vignetteIntensity = Mathf.Lerp(maxVignette, 0, lowestStamina); // High vignette when low stamina

        vignette.intensity.overrideState = true;
        vignette.intensity.value = vignetteIntensity;
    }
}

