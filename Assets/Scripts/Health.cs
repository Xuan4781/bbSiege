using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    public GameManager gameManager;
    public float maxHealth = 100;
    public float currentHealth;

    public Slider healthBar;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        currentHealth = maxHealth;
        if (healthBar != null)
            healthBar.maxValue = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        if (healthBar != null)
            healthBar.value = currentHealth;
    }

    public void TakeDamage(float dmg)
    {
        currentHealth -= dmg;

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        if (gameManager != null){
            gameManager.GameOver();
        } 
        Destroy(gameObject);
    }

    
}
