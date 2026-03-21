using UnityEngine;

public class PlayerSpriteDirection : MonoBehaviour
{
    public Sprite front;
    public Sprite back;
    public Sprite left;
    public Sprite right;

    private SpriteRenderer sr;

    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        float x = Input.GetAxisRaw("Horizontal");
        float y = Input.GetAxisRaw("Vertical");

        if (x == 0 && y == 0) return;

        if (Mathf.Abs(x) > Mathf.Abs(y))
        {
            if (x > 0) sr.sprite = right;
            else sr.sprite = left;
        }
        else
        {
            if (y > 0) sr.sprite = back;
            else sr.sprite = front;
        }
    }
}