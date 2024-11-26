using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeadCollisionHandler : MonoBehaviour
{
    [SerializeField] private HeadCollisionDetector detector;
    [SerializeField] private CharacterController characterController;
    public float pushStrength = 1.0f;

    private Vector3 CalculatePushbackDirection(List<RaycastHit> colliderHits)
    {
        Vector3 combinedNormals = Vector3.zero;
        foreach (RaycastHit hit in colliderHits)
        {
            combinedNormals += new Vector3(hit.normal.x, 0, hit.normal.z);
        }
        return combinedNormals;
    }

    void Update()
    {
        if(detector.hits.Count == 0)
        {
            return;
        }
        Vector3 pushBackDirection = CalculatePushbackDirection(detector.hits);
        characterController.Move(pushBackDirection.normalized * pushStrength * Time.deltaTime);
    }
}
