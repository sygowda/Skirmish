using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chest : MonoBehaviour
{
    // Start is called before the first frame update
    public int health;
    void Start()
    {
        health = 5;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "BulletTag")
        {
            Debug.Log(health);
            if (health > 0)
            {
                health--;
                Debug.Log(health);
            }
            else
            {
                Destroy(gameObject);
            }
        }
    }
}
