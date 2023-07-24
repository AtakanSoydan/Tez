using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;

public class Movement : MonoBehaviour, IDataPersistence
{
    [SerializeField] private Camera _camera;

    private GameObject _gameObject;
    private string groundTag = "Ground";
    private string collectedTag = "Collected";
    private NavMeshAgent agent;
    private RaycastHit hit;
    private Vector3 targetPosition; // Mouse týklama pozisyonunu tutmak için

    private Animator anim;

    [SerializeField] private float stoppingDistance = 2.5f; // Yaklaþma mesafesi

    private void Awake()
    {
        anim = GetComponent<Animator>();  // caching animator
        _gameObject = this.gameObject;
    }

    void Start()
    {
        Debug.Log(Application.persistentDataPath);
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
    public void LoadData(GameData gameData)
    {
        if(SceneManager.GetActiveScene().buildIndex == 1)
        {
            this.transform.position = gameData.playerPosition;
        }
        else{ return;}
    }

    public void SaveData(ref GameData gameData)
    {
        if (SceneManager.GetActiveScene().buildIndex == 1)
        {
            this.transform.position = gameData.playerPosition;
        }
        else{ return;}
    }
}
