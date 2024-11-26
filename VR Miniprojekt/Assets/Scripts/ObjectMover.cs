using UnityEngine;

public class ObjectMover : MonoBehaviour
{
    [Header("Movement Points")]
    public Transform startPoint; 
    public Transform endPoint;   

    [Header("Movement Settings")]
    public float speed = 5f;     
    public bool loop = true;

    private bool movingToEnd = true; 

    void Start()
    {
        
        if (startPoint != null)
            transform.position = startPoint.position;
    }

    void Update()
    {
        if (startPoint == null || endPoint == null)
        {
            Debug.LogWarning("StartPoint or EndPoint is not assigned.");
            return;
        }

       
        MoveObject();
    }

    private void MoveObject()
    {
        
        Transform target = movingToEnd ? endPoint : startPoint;

        transform.position = Vector3.MoveTowards(transform.position, target.position, speed * Time.deltaTime);

        
        if (Vector3.Distance(transform.position, target.position) < 0.01f)
        {
            if (loop)
            {
              
                movingToEnd = !movingToEnd;
            }
            else
            {
               
                enabled = false;
            }
        }
    }
}
