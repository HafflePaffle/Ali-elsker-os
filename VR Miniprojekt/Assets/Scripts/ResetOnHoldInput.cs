using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;

public class ResetOnHoldInput : MonoBehaviour
{
    
    
    public InputActionProperty resetAction; 

   
    public float holdDuration = 2f;

    private float holdTimer = 0f; 

    private void OnEnable()
    {
        
        resetAction.action.Enable();
    }

    private void OnDisable()
    {
        
        resetAction.action.Disable();
    }

    private void Update()
    {
       
        if (resetAction.action.IsPressed())
        {
            holdTimer += Time.deltaTime; 
            if (holdTimer >= holdDuration)
            {
               
                ResetScene();
            }
        }
        else
        {
            
            if (holdTimer > 0f)
            {
                Debug.Log($"ResetOnHoldInput: Button released. Hold time was {holdTimer:F2} seconds.");
            }
            holdTimer = 0f;
        }
    }

    public void ResetScene()
    {
       
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
