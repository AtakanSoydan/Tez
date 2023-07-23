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
            // "Quad" objesinin pozisyonunu al�n
            Vector3 quadPosition = quadObject.transform.position;           
            // Hedef a�� ile kameran�n y eksenindeki a��s� aras�ndaki fark� hesaplar
            float angleDifference = Mathf.Abs(cameraYAngle - targetAngle);
            // Fark, a�� e�ik de�erinden k���k oldu�unda cubeRenderer aktif hale gelir, aksi halde devre d��� kal�r
            cubeRenderer.enabled = angleDifference <= angleThreshold;

            if (cubeRenderer.enabled)
            {
                for (int i = 0; i < gameObject.transform.childCount; i++)
                {
                    var x = gameObject.transform.GetChild(i).gameObject;
                    x.SetActive(true);
                }
                _boxCollider.enabled = true;
            }
            else
            {
                for (int i = 0; i < gameObject.transform.childCount; i++)
                {
                    var x = gameObject.transform.GetChild(i).gameObject;
                    x.SetActive(false);
                }
                _boxCollider.enabled = false;
            }
        }
    }
}
