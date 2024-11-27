using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnowIntensifier : MonoBehaviour
{
    [SerializeField] private ParticleSystem ps;
    [SerializeField] private float intensity = 5;
    [SerializeField] private float maxEmission = 1000f;
    private float currentEmission = 200f;

    private void Start()
    {
        ps = GetComponent<ParticleSystem>();
    }

    // Update is called once per frame
    void Update()
    {
        var emission = ps.emission;
        currentEmission += Time.deltaTime * intensity;
        currentEmission = Mathf.Clamp(currentEmission, 200, maxEmission);
        emission.rateOverTime = currentEmission;
    }
}
