using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.PostProcessing;

public class VignetteAdjuster : MonoBehaviour
{
    private Volume volume;

    private void Start()
    {
        volume = GetComponent<Volume>();
        volume.enabled = false;
    }

    private IEnumerator doVignetteCoroutine()
    {
        volume.enabled = true;
        yield return new WaitForSeconds(1f);
        volume.enabled = false;
    }

    public void doVignette()
    {
        StartCoroutine(doVignetteCoroutine());
    }
}
