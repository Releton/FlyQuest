using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class VignetteAdjuster : MonoBehaviour
{
    private Vignette vignette;
    private PostProcessVolume vol;
    private float duration;

    private void Start()
    {
        vol = GetComponent<PostProcessVolume>();
        print(vol);
        vol.profile.TryGetSettings(out vignette);
    }


    private void Update()
    {
        if(duration > 0)
        {
            duration -= Time.deltaTime;
            if(duration <= 0)
            {
                vignette.color.Override(Color.green);
                vignette.intensity.Override(0.37f);
                vignette.smoothness.Override(0.54f);
            }
        }
    }
    public void GreenVignette(float duration)
    {
        Debug.Log(vol);
        if (vignette != null)
        {
            vignette.color.Override(Color.red);
            vignette.intensity.Override(0.37f);
            vignette.smoothness.Override(0.54f);
        }
        this.duration = duration;
    }

    public void RedVignette(float duration)
    {
        if (vignette != null)
        {
            vignette.color.value = new Color(255f, 36f, 28f);
            vignette.intensity.value = 0.37f;
            vignette.smoothness.value = 0.54f;
        }
        this.duration = duration;
    }
}
