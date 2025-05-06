using UnityEngine;

public class EnemyController : MonoBehaviour
{
    private Rigidbody rb;
    private Transform playerTransform;

    [SerializeField] private float speed = 5f;

    private readonly float yLimit = -5;

    private SpawnManager spawnManager;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        playerTransform = FindObjectOfType<PlayerController>().transform;
        spawnManager = FindObjectOfType<SpawnManager>();
    }

    void Update()
    {
        if(transform.position.y < yLimit)
        {
            spawnManager.DestroyEnemy(gameObject);
            Destroy(gameObject);
        } 
    }

    void FixedUpdate()
    {
        rb.AddForce(DirectionToPlayer() * speed);
    }

    Vector3 DirectionToPlayer()
    {
        Vector3 direction = playerTransform.position - transform.position;
        direction.Normalize();

        return direction;
    }
}
