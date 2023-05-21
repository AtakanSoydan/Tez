using UnityEngine;

public class HideBehindQuad : MonoBehaviour
{
    public GameObject quadObject;
    private Renderer cubeRenderer;
    public float targetAngle = 225f;
    private float angleThreshold = 40f;

    private BoxCollider _boxCollider;

    
    private void Start()
    {
        cubeRenderer = GetComponent<Renderer>();
        _boxCollider = GetComponent<BoxCollider>();
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

            if (cubeRenderer.enabled)
            {
                _boxCollider.enabled = true;
                var x = gameObject.transform.GetChild(0).gameObject;
                x.SetActive(true);

            }
            else
            {
                _boxCollider.enabled = false;
                var x = gameObject.transform.GetChild(0).gameObject;
                x.SetActive(false);
            }

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
