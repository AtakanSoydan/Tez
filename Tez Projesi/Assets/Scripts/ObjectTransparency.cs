using UnityEngine;

public class ObjectTransparency : MonoBehaviour
{
    public Transform player;
    public float fadeSpeed;
    public float fadeAmount;

    private void Update()
    {
        // Kameranýn konumu ve oyuncunun konumu arasýnda bir vektör oluþtur
        Vector3 cameraToPlayer = player.position - Camera.main.transform.position;

        // Kameranýn baktýðý yöne doðru bir ray oluþtur
        Ray ray = new Ray(Camera.main.transform.position, cameraToPlayer);
        RaycastHit[] hits;
        hits = Physics.RaycastAll(ray, cameraToPlayer.magnitude);

        Debug.DrawRay(ray.origin, ray.direction * 10f, Color.red, 1f);

        foreach (RaycastHit hit in hits)
        {
            // Eðer raycast sonucunda bir obje bulunduysa ve obje bir Renderer bileþeni içeriyorsa
            if (hit.collider != null && hit.collider.GetComponent<Renderer>() != null)
            {
                Renderer renderer = hit.collider.GetComponent<Renderer>();

                Color materialColor = renderer.material.color;
                float targetAlpha = Mathf.Lerp(materialColor.a, fadeAmount, fadeSpeed * Time.deltaTime);
                materialColor.a = targetAlpha;
                renderer.material.color = materialColor;

            }
        }
    }
}
