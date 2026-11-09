using UnityEngine;
using Unity.Cinemachine;
using System.Collections; //referebnciar librería de cinemachine

public class VirtualCameraManager : MonoBehaviour
{
    public CinemachineCamera[] virtualCamList;
    public CinemachineCamera currentCamera;
    public static VirtualCameraManager instance;
    public KeyCode shakeDebugKey;


    private void Awake()
    {
        instance = this;     
    }

    void Start()
    {
        //Asingar la prioridad de las cámaras conforme a su orden en la lista
        for(int i = 0; i < virtualCamList.Length; i++)
        {
            virtualCamList[i].Priority = i;
        }

        SwitchCamera(0);

    }

    public void SwitchCamera(int cameraId)
    {
        int clampIndex = Mathf.Clamp(cameraId, 0, virtualCamList.Length - 1);

        for (int i = 0; i < virtualCamList.Length; i++)
        {
            if (virtualCamList[i].Priority == clampIndex)
            {
                virtualCamList[i].gameObject.SetActive(true);
                currentCamera = virtualCamList[i];
            }
            else
            {
                virtualCamList[i].gameObject.SetActive(false);
            }
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(shakeDebugKey))
        {
            ShakeCamera(5, 2, 1);
        }
    }

    public void ShakeCamera(float amplitude, float frequency, float duration)
    {
        CinemachineBasicMultiChannelPerlin noise = currentCamera.GetComponent<CinemachineBasicMultiChannelPerlin>();

        if(noise == null)
        {
            return;
        }

        StartCoroutine(ShakeCameraRoutine(noise, amplitude, frequency, duration));
    }

    private void StopShake(CinemachineBasicMultiChannelPerlin noise)
    {
        noise.AmplitudeGain = 0;
        noise.FrequencyGain = 0;
    }

    IEnumerator ShakeCameraRoutine(CinemachineBasicMultiChannelPerlin noise, float amplitude, float frequency, float duration)
    {
        noise.AmplitudeGain = amplitude;
        noise.FrequencyGain = frequency;

        yield return new WaitForSeconds(duration);
        StopShake(noise);
    }
}
