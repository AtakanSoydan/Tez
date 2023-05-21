using UnityEngine;

public class InfoCanvasRotation : MonoBehaviour
{
    private Transform mainCameraTransform;

    private void Start()
    {
        // Ana kameranýn transform bileþenini al
        mainCameraTransform = Camera.main.transform;
    }

    private void LateUpdate()
    {
        // Info Canvas'ýný ana kameraya doðru döndür
        transform.LookAt(transform.position + mainCameraTransform.rotation * Vector3.forward,
            mainCameraTransform.rotation * Vector3.up);
    }
}
