using System.Collections;
using System.Collections.Generic;
using UnityEditor.ShaderGraph.Internal;
using UnityEngine;

public class raycasting : MonoBehaviour
{
    public float Height;
    RaycastHit hit;
   
    private void Update()
    {
        Ray ray = new Ray(transform.position, -Vector3.up);

        if (Physics.Raycast(ray, out hit))
        {
            if(hit.collider.tag == "ground") 
            
            {
                Debug.Log(hit.distance);
                Height = (float)hit.distance;
            }

        }
    }
}
