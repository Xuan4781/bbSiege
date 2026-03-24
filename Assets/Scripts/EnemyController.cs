using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
    NavMeshAgent agent;
    Transform player;
    Transform baseTarget;

    public GameObject bulletPrefab;
    public float shootRate = 0.5f;
    public float bulletSpeed = 8f;
    float shootTimer;

    public float detectRange = 5f;
    Transform target;
    public AudioClip shootSound;
    private AudioSource audioSource;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {   
        audioSource = GetComponent<AudioSource>();
        agent = GetComponent<NavMeshAgent>();

        GameObject playerObj = GameObject.FindGameObjectWithTag("Player");
        if (playerObj != null)
        {
            player = playerObj.transform;
        }
         GameObject baseObj = GameObject.FindGameObjectWithTag("Base");
        if (baseObj != null)
        {
            baseTarget = baseObj.transform;
        }
            
    }

    // Update is called once per frame
    void Update()
    {
        if (player == null|| baseTarget == null) return;

        // decide target
        float distanceToPlayer = Vector3.Distance(transform.position, player.position);
        target = (distanceToPlayer < detectRange) ? player : baseTarget;
        
        agent.SetDestination(target.position);
        // Shooting timer
        shootTimer += Time.deltaTime;

        if (shootTimer >= shootRate)
        {
            Shoot();
            shootTimer = 0f;
        }
    }

    void Shoot()
    {
        audioSource.PlayOneShot(shootSound);
        Vector3 direction = (target.position - transform.position).normalized;
        Vector3 spawnPos = transform.position + Vector3.up * 1f;
        GameObject bullet = Instantiate(bulletPrefab, spawnPos, Quaternion.identity);
        bullet.GetComponent<Bullet>().ownerTag = "Enemy";

        Rigidbody rb = bullet.GetComponent<Rigidbody>();

        rb.linearVelocity = direction * bulletSpeed;

        Physics.IgnoreCollision(
            bullet.GetComponent<Collider>(),
            GetComponent<Collider>()
        );
    }
}
