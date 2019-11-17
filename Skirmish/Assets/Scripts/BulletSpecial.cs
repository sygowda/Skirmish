using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletSpecial : MonoBehaviour
{
    public float speed = 20f;
    public Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        rb.velocity = transform.right * speed;
    }

    private void Update()
    {
        if(GameController.instance.gameOver == true)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Brick brick = collision.GetComponent<Brick>();
        if(brick != null)
        {
            brick.TakeDamage(50);
        }
        Destroy(gameObject);
    }

    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}
