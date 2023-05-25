using UnityEngine;
using UnityEngine.AI;

public class Movement : MonoBehaviour
{
    [SerializeField] private Camera _camera;

    private string groundTag = "Ground";
    private string collectedTag = "Collected";
    private NavMeshAgent agent;
    private RaycastHit hit;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
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
                    agent.SetDestination(hit.point);
                }
            }
        }
    }
}
