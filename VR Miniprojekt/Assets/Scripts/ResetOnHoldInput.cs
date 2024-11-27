using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;

public class ResetOnHoldInput : MonoBehaviour
{
    [Header("Input Action Reference")]
    [Tooltip("Reference to the Input Action for the reset button (e.g., X button on Quest 3).")]
    public InputActionProperty resetAction; // Input Action for the reset button

    [Header("Hold Settings")]
    [Tooltip("How long the button must be held down to reset the scene (in seconds).")]
    public float holdDuration = 2f;

    private float holdTimer = 0f; // Tracks how long the button is held

    private void OnEnable()
    {
        // Enable the input action when the script is enabled
        resetAction.action.Enable();
    }

    private void OnDisable()
    {
        // Disable the input action when the script is disabled
        resetAction.action.Disable();
    }

    private void Update()
    {
        // Check if the reset button is being pressed
        if (resetAction.action.IsPressed())
        {
            holdTimer += Time.deltaTime; // Increment the hold timer
            if (holdTimer >= holdDuration)
            {
                Debug.Log("ResetOnHoldInput: Button held for required duration. Resetting scene...");
                ResetScene();
            }
        }
        else
        {
            // Reset the hold timer if the button is released
            if (holdTimer > 0f)
            {
                Debug.Log($"ResetOnHoldInput: Button released. Hold time was {holdTimer:F2} seconds.");
            }
            holdTimer = 0f;
        }
    }

    public void ResetScene()
    {
        Debug.Log("ResetOnHoldInput: Reloading current scene...");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
