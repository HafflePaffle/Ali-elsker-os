using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor.ShaderGraph.Internal;
using UnityEngine;

public class raycasting : MonoBehaviour
{
    public float Height;
    RaycastHit hit;
    public TextMeshProUGUI heightDisplay;
    public LayerMask layerMask;

    private void Update()
    {
        Ray ray = new Ray(transform.position, -Vector3.up);

        if (Physics.Raycast(ray, out hit, Mathf.Infinity, layerMask))
        {
            if(hit.collider.tag == "ground") 
            
            {
                Debug.Log(hit.distance);
                Height = (float)hit.distance;

                if (heightDisplay != null)
                { 
                    heightDisplay.text = $"Height: {Height:F2}";

                }
               
            }

        }
    }
}
