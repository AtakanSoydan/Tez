using UnityEngine;

public class RotationScript : MonoBehaviour
{
    public float rotationSpeed = 60f; // Haritan�n d�nme h�z�

    private bool isRotating = false;
    private float targetRotation = 0f;

    // Update her frame'de �a�r�l�r
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

        // E�er "Q" tu�una bas�l�rsa harita saat y�n�nde d�ner
        if (Input.GetKeyDown(KeyCode.Q) && !isRotating)
        {
            targetRotation -= 60f;
            isRotating = true;
            Debug.Log("Q Tu�una Bas�ld� - Target Rotation Bilgisi -60f de�i�ti " + targetRotation);
        }

        // E�er "E" tu�una bas�l�rsa harita saat y�n�n�n tersine d�ner
        if (Input.GetKeyDown(KeyCode.E) && !isRotating)
        {
            targetRotation += 60f;
            isRotating = true;
            Debug.Log("E Tu�una Bas�ld� - Target Rotation Bilgisi +60f de�i�ti " + targetRotation);
        }
    }
}
