using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletSpecial : MonoBehaviour
{
    public float speed = 15f;
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
        if (collision.gameObject.tag == "Player1Tag" || collision.gameObject.tag == "Player2Tag")
        {
            GameController.instance.gameOverWithSpecialBullet = true;
            GameController.instance.GameOver(collision.gameObject.tag == "Player1Tag" ? 2 : 1);
        }
        if (collision.gameObject.tag != "BulletTag")
            Destroy(gameObject);
    }

    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}
