using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
    NavMeshAgent agent;
    Transform player;

    public GameObject bulletPrefab;
    public float shootRate = 2f;
    public float bulletSpeed = 8f;
    float shootTimer;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();

        GameObject playerObj = GameObject.FindGameObjectWithTag("Player");
        if (playerObj != null)
        {
            player = playerObj.transform;
        }
        else
        {
            Debug.LogError("Player not found! Make sure it's tagged 'Player'");
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (player == null) return;
        agent.SetDestination(player.position);
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

        Vector3 direction = (player.position - transform.position).normalized;
        Vector3 spawnPos = transform.position + Vector3.up * 1f;
        GameObject bullet = Instantiate(bulletPrefab, spawnPos, Quaternion.identity);

        Rigidbody rb = bullet.GetComponent<Rigidbody>();

        rb.linearVelocity = direction * bulletSpeed;

        Physics.IgnoreCollision(
            bullet.GetComponent<Collider>(),
            GetComponent<Collider>()
        );
    }
}
