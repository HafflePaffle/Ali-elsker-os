using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeadCollisionDetector : MonoBehaviour
{
    [SerializeField, Range(0, 0.5f)] private float detectDelay = 0.05f;
    [SerializeField] private float detectDistance = 0.2f;
    [SerializeField] private LayerMask detectLayers;
    public List<RaycastHit> hits {  get; private set; }

    private float time = 0;

    [field: SerializeField] public bool InsideCollider {  get; private set; }

    private List<RaycastHit> PerformDetection(Vector3 position, float distance, LayerMask layerMask)
    {
        List<RaycastHit> raycastHits = new List<RaycastHit>();

        List<Vector3> directions = new() { transform.forward, transform.right, -transform.right };

        RaycastHit hit;
        foreach(Vector3 dir in directions)
        {
            if(Physics.Raycast(position, dir,  out hit, distance, layerMask))
            {
                raycastHits.Add(hit);
            }
        }
        return raycastHits;
    }

    private void Start()
    {
        hits = PerformDetection(transform.position, detectDistance, detectLayers);
    }

    private void Update()
    {
        time += Time.deltaTime;
        if (time > detectDelay)
        {
            time = 0;
            InsideCollider = false;
            hits = PerformDetection(transform.position, detectDistance, detectLayers);
            if(hits.Count == 0)
            {
                InsideCollider = CheckIfInsideCollider(transform.position, detectDistance, detectLayers);
            }
        }
    }

    public bool CheckIfInsideCollider(Vector3 position, float distance, LayerMask layerMask)
    {
        return Physics.CheckSphere(position, distance, layerMask, QueryTriggerInteraction.Ignore);
    }
}
