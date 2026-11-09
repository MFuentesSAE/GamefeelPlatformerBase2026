using UnityEngine;

public class VirtualCameraTrigger : MonoBehaviour
{
    public int cameraToSwitch;
    private string playerTag = "Player";

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag(playerTag))
        {
            VirtualCameraManager.instance.SwitchCamera(cameraToSwitch);
        }
    }
}
