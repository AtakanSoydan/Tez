using UnityEngine;

public class ObjectTransparency : MonoBehaviour
{
    public Transform player;
    public float fadeSpeed;
    public float fadeAmount;

    private void Update()
    {
        // Kameran�n konumu ve oyuncunun konumu aras�nda bir vekt�r olu�tur
        Vector3 cameraToPlayer = player.position - Camera.main.transform.position;

        // Kameran�n bakt��� y�ne do�ru bir ray olu�tur
        Ray ray = new Ray(Camera.main.transform.position, cameraToPlayer);
        RaycastHit[] hits;
        hits = Physics.RaycastAll(ray, cameraToPlayer.magnitude);

        Debug.DrawRay(ray.origin, ray.direction * 10f, Color.red, 1f);

        foreach (RaycastHit hit in hits)
        {
            // E�er raycast sonucunda bir obje bulunduysa ve obje bir Renderer bile�eni i�eriyorsa
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
