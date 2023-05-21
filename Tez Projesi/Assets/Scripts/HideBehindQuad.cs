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
            // "Quad" objesinin arkasýnda yer alan "Cube" objesinin pozisyonunu alýn
            Vector3 cubePosition = transform.position;
            Debug.Log(cubePosition);
            // "Quad" objesinin pozisyonunu alýn
            Vector3 quadPosition = quadObject.transform.position;
            Debug.Log(quadPosition);

            // Hedef açý ile kameranýn y eksenindeki açýsý arasýndaki farký hesaplar
            float angleDifference = Mathf.Abs(cameraYAngle - targetAngle);

            // Fark, açý eþik deðerinden küçük olduðunda cubeRenderer aktif hale gelir, aksi halde devre dýþý kalýr
            cubeRenderer.enabled = angleDifference <= angleThreshold;

            //// Hedef açý ile kameranýn y eksenindeki açýsýný karþýlaþtýrýr
            //if (Mathf.Approximately(cameraYAngle, targetAngle))
            //{
            //    Debug.Log("Kamera y ekseninde hedef açýya sahip.");
            //    Debug.Log(Vector3.Dot(quadPosition - cubePosition, transform.forward));
            //    // "Cube" objesinin "Quad" objesinin önünde mi arkasýnda mý olduðunu kontrol et
            //    bool isBehindQuad = Vector3.Dot(quadPosition - cubePosition, transform.forward) > 0;
            //    // "Cube" objesinin görünürlüðünü ayarla
            //    cubeRenderer.enabled = !isBehindQuad;
            //}
            //else
            //{
            //    Debug.Log("Kamera y ekseninde hedef açýya sahip deðil.");
            //    Debug.Log(Vector3.Dot(quadPosition - cubePosition, quadObject.transform.forward));               
            //    bool isBehindQuad = Vector3.Dot(quadPosition - cubePosition, quadObject.transform.forward) > 0;
            //    cubeRenderer.enabled = !isBehindQuad;
            //}
        }
    }
}
