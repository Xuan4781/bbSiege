using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    public GameManager gameManager;
    public float maxHealth = 100f;
    public float currentHealth;
    public Image healthBarFill;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        currentHealth = maxHealth;
        UpdateHealthBar();
            
    }

    // Update is called once per frame
    public void UpdateHealthBar()
    {
        if (healthBarFill != null)
        {
            healthBarFill.fillAmount = currentHealth / maxHealth;
        }
    }

    public void TakeDamage(float dmg)
    {
        Debug.Log(gameObject.name + " took damage: " + dmg);
        currentHealth -= dmg;
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);

        UpdateHealthBar();

        if (currentHealth <= 0)
        {
            Die();
        }
    }
    public void Heal(float amount)
    {
        currentHealth += amount;
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);

        UpdateHealthBar();
    }

    void Die()
    {
        if (gameObject.CompareTag("Base") && gameManager != null)
        {
            gameManager.GameOver();
        }

        if (gameObject.CompareTag("Player") && gameManager != null)
        {
            gameManager.GameOver();
        }

        Destroy(gameObject);
    }

    
}
