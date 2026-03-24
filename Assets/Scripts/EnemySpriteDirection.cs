using UnityEngine;
using UnityEngine.AI;

public class EnemySpriteDirection : MonoBehaviour
{
    public Sprite front;
    public Sprite back;
    public Sprite left;
    public Sprite right;

    private SpriteRenderer sr;
    private NavMeshAgent agent;

    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        agent = GetComponent<NavMeshAgent>();

        agent.updateRotation = false;
        agent.updateUpAxis = false;
    }

    void Update()
    {
        if (agent == null || agent.velocity.sqrMagnitude < 0.01f)
            return;

        Vector3 dir = agent.velocity.normalized;

        float x = dir.x;
        float z = dir.z;

        if (Mathf.Abs(x) > Mathf.Abs(z))
        {
            if (x > 0) sr.sprite = right;
            else sr.sprite = left;
        }
        else
        {
            if (z > 0) sr.sprite = back;
            else sr.sprite = front;
        }
    }
}