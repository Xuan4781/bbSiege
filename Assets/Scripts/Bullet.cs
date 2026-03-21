using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float damage = 25f;
    public string ownerTag;

     void OnCollisionEnter(Collision collision)
    {
        GameObject hit = collision.gameObject;
        Debug.Log("Bullet hit: " + hit.name);
       
        if (ownerTag == "Player" && hit.CompareTag("Base"))
        {
            Destroy(gameObject);
            return;
        }

        Health h = hit.GetComponentInParent<Health>();
        Debug.Log("Health found = " + (h != null));
        if (h != null)
        {
            Debug.Log(hit.name + " took damage: " + damage);
            h.TakeDamage(damage);
        }

        Destroy(gameObject);
    }

}
