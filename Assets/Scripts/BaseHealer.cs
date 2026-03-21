using UnityEngine;

public class BaseHealer : MonoBehaviour
{
    public float healRate = 5f;
    public float healRadius = 5f;

    public LayerMask playerLayer;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Collider[] hits = Physics.OverlapSphere(transform.position, healRadius, playerLayer);

        foreach (Collider hit in hits)
        {
            Health playerHealth = hit.GetComponentInParent<Health>();

            if (playerHealth != null)
            {
                float before = playerHealth.currentHealth;
                playerHealth.currentHealth += healRate * Time.deltaTime;
                playerHealth.currentHealth = Mathf.Min(playerHealth.currentHealth, playerHealth.maxHealth);
                playerHealth.UpdateHealthBar();
                Debug.Log("Healing " + hit.name + ": " + before + " to " + playerHealth.currentHealth);
            }
        }
    }
    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, healRadius);
    }
}
