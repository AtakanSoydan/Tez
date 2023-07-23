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
            // "Quad" objesinin arkasýnda yer alan "Cube" objesinin pozisyonunu alýn
            Vector3 cubePosition = transform.position;      
            // "Quad" objesinin pozisyonunu alýn
            Vector3 quadPosition = quadObject.transform.position;           
            // Hedef açý ile kameranýn y eksenindeki açýsý arasýndaki farký hesaplar
            float angleDifference = Mathf.Abs(cameraYAngle - targetAngle);
            // Fark, açý eþik deðerinden küçük olduðunda cubeRenderer aktif hale gelir, aksi halde devre dýþý kalýr
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
