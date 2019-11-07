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
    public static GameController gc;
    TextMeshPro tmp;
    void Start()
    {
        gc = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>();
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
                if (p1) {
                    gc.p1_total -= UserData.getChest1(index);
                    gc.p2_total += UserData.getChest1(index);
                }
                else
                {
                    gc.p1_total += UserData.getChest2(index);
                    gc.p2_total -= UserData.getChest2(index);
                }


                    Destroy(gameObject);
            }
        }
    }
}
