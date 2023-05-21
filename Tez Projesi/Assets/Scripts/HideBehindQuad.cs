using UnityEngine;

public class HideBehindQuad : MonoBehaviour
{
    public GameObject quadObject;
    private Renderer cubeRenderer;
    public float targetAngle = 225f;
    private float angleThreshold = 15f;

    private void Start()
    {
        cubeRenderer = GetComponent<Renderer>();
    }

    private void Update()
    {
        if (quadObject != null)
        {
            Quaternion cameraRotation = Camera.main.transform.rotation;
            float cameraYAngle = cameraRotation.eulerAngles.y;
            // "Quad" objesinin arkas�nda yer alan "Cube" objesinin pozisyonunu al�n
            Vector3 cubePosition = transform.position;
            Debug.Log(cubePosition);
            // "Quad" objesinin pozisyonunu al�n
            Vector3 quadPosition = quadObject.transform.position;
            Debug.Log(quadPosition);

            // Hedef a�� ile kameran�n y eksenindeki a��s� aras�ndaki fark� hesaplar
            float angleDifference = Mathf.Abs(cameraYAngle - targetAngle);

            // Fark, a�� e�ik de�erinden k���k oldu�unda cubeRenderer aktif hale gelir, aksi halde devre d��� kal�r
            cubeRenderer.enabled = angleDifference <= angleThreshold;

            //// Hedef a�� ile kameran�n y eksenindeki a��s�n� kar��la�t�r�r
            //if (Mathf.Approximately(cameraYAngle, targetAngle))
            //{
            //    Debug.Log("Kamera y ekseninde hedef a��ya sahip.");
            //    Debug.Log(Vector3.Dot(quadPosition - cubePosition, transform.forward));
            //    // "Cube" objesinin "Quad" objesinin �n�nde mi arkas�nda m� oldu�unu kontrol et
            //    bool isBehindQuad = Vector3.Dot(quadPosition - cubePosition, transform.forward) > 0;
            //    // "Cube" objesinin g�r�n�rl���n� ayarla
            //    cubeRenderer.enabled = !isBehindQuad;
            //}
            //else
            //{
            //    Debug.Log("Kamera y ekseninde hedef a��ya sahip de�il.");
            //    Debug.Log(Vector3.Dot(quadPosition - cubePosition, quadObject.transform.forward));               
            //    bool isBehindQuad = Vector3.Dot(quadPosition - cubePosition, quadObject.transform.forward) > 0;
            //    cubeRenderer.enabled = !isBehindQuad;
            //}
        }
    }
}
