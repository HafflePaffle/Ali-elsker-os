using UnityEngine;
using UnityEngine.SceneManagement;

public class ResetOnCollision : MonoBehaviour
{
    public GameObject targetObject;
   
    private void OnCollisionEnter(Collision collision)
    {

        if (collision.gameObject == targetObject)
        {
            ResetScene();
        }
    }

    public void ResetScene()
    {
        
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
