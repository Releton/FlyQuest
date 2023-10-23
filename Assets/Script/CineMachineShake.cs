using Cinemachine;
using UnityEngine;

public class CineMachineShake : MonoBehaviour
{
    public static CineMachineShake Instance { get; private set; }
    private CinemachineVirtualCamera cvc;
    private float shakeTimer;
    private void Awake()
    {
        Instance = this;
        cvc = GetComponent<CinemachineVirtualCamera>();
    }

    public void shakeCamera(float intensity, float time)
    {
        CinemachineBasicMultiChannelPerlin basicPerlin = cvc.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();
        basicPerlin.m_AmplitudeGain = intensity;
        shakeTimer = time;
    }
    private void Update()
    {
        if(shakeTimer > 0)
        {
            shakeTimer -= Time.deltaTime;
            if(shakeTimer <= 0f)
            {
                CinemachineBasicMultiChannelPerlin basicPerlin = cvc.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();
                basicPerlin.m_AmplitudeGain = 0f;
            }
        }

    }
}
