using UnityEngine;

public class BaseHealer : MonoBehaviour
{
    public Health playerHealth;
    public float healRate = 5f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (playerHealth != null)
        {
            playerHealth.currentHealth += healRate * Time.deltaTime;

            if (playerHealth.currentHealth > playerHealth.maxHealth)
                playerHealth.currentHealth = playerHealth.maxHealth;
        }
    }
}
