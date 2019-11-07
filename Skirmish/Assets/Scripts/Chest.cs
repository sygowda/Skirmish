using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Chest : MonoBehaviour
{
    // Start is called before the first frame update
    public int health;
    public GameObject text;
    public bool p1;//true for p1's chest
    public int index;
    TextMeshPro tmp;
    void Start()
    {
        health = 5;
        tmp = text.GetComponent<TextMeshPro>();
    }

    // Update is called once per frame
    void Update()
    {
        tmp.text = health.ToString();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "BulletTag")
        {
            Debug.Log(health);
            if (health > 1)
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
