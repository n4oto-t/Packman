using UnityEngine;

public class PackmanMove : MonoBehaviour
{

    public float speed = 0.4f;
    Vector2 dest = Vector2.zero;
    void Start()
    {
        dest = transform.position;
    }
    void FixedUpdate()
    {
        Vector2 p = Vector2.MoveTowards(transform.position, dest, speed);
        GetComponent<Rigidbody2D>().MovePosition(p);


        if ((Vector2)transform.position != dest)
        {
            if (Input.GetKey(KeyCode.UpArrow) && Valid(Vector2.up))
                dest = (Vector2)transform.position + Vector2.up;
            if (Input.GetKey(KeyCode.RightArrow) && Valid(Vector2.right))
                dest = (Vector2)transform.position + Vector2.right;
            if (Input.GetKey(KeyCode.DownArrow) && Valid(-Vector2.up))
                dest = (Vector2)transform.position - Vector2.up;
            if (Input.GetKey(KeyCode.LeftArrow) && Valid(-Vector2.right))
                dest = (Vector2)transform.position - Vector2.right;

        }
    }

    bool Valid(Vector2 dir)
    {
        // pacmanと移動先を線で結び、その線がなんらかのオブジェクトに接触したら壁と認識?
        Vector2 pos = transform.position;
        RaycastHit2D hit = Physics2D.Linecast(pos + dir, pos);
        return hit.collider == GetComponent<Collider2D>();
    }
}
