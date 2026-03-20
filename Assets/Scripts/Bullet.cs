using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float damage = 25f;

     void OnCollisionEnter(Collision collision)
    {
        Health h = collision.gameObject.GetComponent<Health>();

        if (h != null)
        {
            h.TakeDamage(damage);
        }

        Destroy(gameObject);
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Destroy(gameObject, 5f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
