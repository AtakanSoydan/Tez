using UnityEngine;

public class RotationScript : MonoBehaviour
{
    public float rotationSpeed = 60f; // Haritanýn dönme hýzý

    private bool isRotating = false;
    private float targetRotation = 0f;

    // Update her frame'de çaðrýlýr
    void Update()
    {
        if (isRotating)
        {
            float step = rotationSpeed * Time.deltaTime;
            transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.Euler(0f, targetRotation, 0f), step);

            if (Mathf.Abs(transform.rotation.eulerAngles.y - targetRotation) < 0.1f)
            {
                isRotating = false;
            }
        }

        // Eðer "Q" tuþuna basýlýrsa harita saat yönünde döner
        if (Input.GetKeyDown(KeyCode.Q) && !isRotating)
        {
            targetRotation -= 60f;
            isRotating = true;
            Debug.Log("Q Tuþuna Basýldý - Target Rotation Bilgisi -60f deðiþti " + targetRotation);
        }

        // Eðer "E" tuþuna basýlýrsa harita saat yönünün tersine döner
        if (Input.GetKeyDown(KeyCode.E) && !isRotating)
        {
            targetRotation += 60f;
            isRotating = true;
            Debug.Log("E Tuþuna Basýldý - Target Rotation Bilgisi +60f deðiþti " + targetRotation);
        }
    }
}
