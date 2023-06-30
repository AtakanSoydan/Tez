using UnityEngine;
using UnityEngine.AI;

public class Movement : MonoBehaviour
{
    [SerializeField] private Camera _camera;

    private string groundTag = "Ground";
    private string collectedTag = "Collected";
    private NavMeshAgent agent;
    private RaycastHit hit;
    private Vector3 targetPosition; // Mouse týklama pozisyonunu tutmak için

    private Animator anim;

    [SerializeField] private float stoppingDistance = 1.5f; // Yaklaþma mesafesi

    private void Awake()
    {
        anim = GetComponent<Animator>();  // caching animator
    }

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.stoppingDistance = stoppingDistance; // Yaklaþma mesafesini ayarla
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = _camera.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit, Mathf.Infinity))
            {
                if (hit.collider.CompareTag(groundTag) || hit.collider.CompareTag(collectedTag))
                {
                    targetPosition = hit.point; // Mouse týklama pozisyonunu kaydet
                    agent.SetDestination(targetPosition);
                    anim.SetBool("Aim", true);
                }
                else
                {
                    anim.SetBool("Aim", false);
                }
            }
            else
            {
                anim.SetBool("Aim", false);
            }
        }

        // Agent'ýn konumu ile mouse týklamasý ile oluþan ray'in konumunu kontrol etmek
        if (agent.remainingDistance <= agent.stoppingDistance && !agent.pathPending)
        {
            // Agent hedefe ulaþtýðýnda kontrol etmek yerine, Agent'ýn hedefine doðru bakmasýný saðlayabilirsiniz.
            Vector3 lookAtTarget = new Vector3(targetPosition.x, transform.position.y, targetPosition.z);
            transform.LookAt(lookAtTarget);
            anim.SetBool("Aim", false);
        }
    }
}
