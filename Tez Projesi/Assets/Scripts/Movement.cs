using UnityEngine;
using UnityEngine.AI;

public class Movement : MonoBehaviour
{
    [SerializeField]
    private Camera camera;

    private string groundTag = "Ground";
    private string collectedTag = "Collected";

    private NavMeshAgent agent;

    private RaycastHit hit;

    // Called when a script is enabled
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    // Called once every frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = camera.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit, Mathf.Infinity))
            {
                if (hit.collider.CompareTag(groundTag) || hit.collider.CompareTag(collectedTag)) 
                {
                    agent.SetDestination(hit.point);
                }
            }
        }
    }
}
