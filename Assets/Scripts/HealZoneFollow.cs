using UnityEngine;

public class HealZoneFollow : MonoBehaviour
{
    public Transform baseTransform;

    void Update()
    {
        transform.position = baseTransform.position + Vector3.up * 0.05f;
    }
}