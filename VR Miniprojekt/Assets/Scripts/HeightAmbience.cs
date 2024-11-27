using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeightAmbience : MonoBehaviour
{
    [SerializeField] private raycasting height;
    [SerializeField] private float maxHeight = 10;
    private AudioSource audioS;

    private void Start()
    {
        if (height == null)
            Debug.Log("Missing height measurer");
        audioS = GetComponent<AudioSource>();
    }

    private void Update()
    {
        float heightRatio = height.Height / maxHeight;
        heightRatio = Mathf.Clamp01(heightRatio);
        audioS.volume = heightRatio;
    }
}
