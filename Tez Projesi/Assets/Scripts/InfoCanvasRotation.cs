using UnityEngine;

public class InfoCanvasRotation : MonoBehaviour
{
    private Transform mainCameraTransform;

    private void Start()
    {
        // Ana kameran�n transform bile�enini al
        mainCameraTransform = Camera.main.transform;
    }

    private void LateUpdate()
    {
        // Info Canvas'�n� ana kameraya do�ru d�nd�r
        transform.LookAt(transform.position + mainCameraTransform.rotation * Vector3.forward,
            mainCameraTransform.rotation * Vector3.up);
    }
}
