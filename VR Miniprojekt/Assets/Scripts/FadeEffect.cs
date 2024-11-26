using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeEffect : MonoBehaviour
{
    [SerializeField] private float fadeDelay = 0.07f;
    private Material material;

    private bool isFading = false;

    private void Start()
    {
        material = GetComponent<MeshRenderer>().material;
    }

    public void Fade(bool fade)
    {
        if (fade == isFading)
            return;

        isFading = fade;
        StopAllCoroutines();
        StartCoroutine(PlayEffect(fade));
    }

    private IEnumerator PlayEffect(bool fade)
    {
        float startAlpha = material.GetFloat("_Alpha");
        float endAlpha = fade ? 1.0f : 0.0f;
        float remainingTime = fadeDelay * Mathf.Abs(endAlpha - startAlpha);

        float elapsedTime = 0;
        while (elapsedTime < fadeDelay)
        {
            elapsedTime += Time.deltaTime;
            float tempVal = Mathf.Lerp(startAlpha, endAlpha, elapsedTime/remainingTime);

            material.SetFloat("_Alpha", tempVal);
            yield return null;
        }
        material.SetFloat("_Alpha", endAlpha);
    }
}
