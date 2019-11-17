using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Chest : MonoBehaviour
{
    // Start is called before the first frame update
    public int health;
    public GameObject text;
    public bool p1;//true for upperplayer
    public int index;
    TextMeshPro tmp;
    public GameController gc;
    void Start()
    {
        health = 5;
        tmp = text.GetComponent<TextMeshPro>();
        gc = GameObject.Find("GameController").GetComponent<GameController>();
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
            //Debug.Log(health);
            if (health > 1)
            {
                health--;
                //Debug.Log(health);
            }
            else
            {
                if (p1)
                {
                    Debug.Log("come through this place!");

                    gc.p1_total -= UserData.getChest1(index);
                    gc.p2_total += UserData.getChest1(index);
                    ChestDestroyAnalytics.setP1ChestDestroyedTime();
                }
                else
                {
                    Debug.Log("come through that place!");

                    gc.p1_total += UserData.getChest2(index);
                    gc.p2_total -= UserData.getChest2(index);
                    ChestDestroyAnalytics.setP2ChestDestroyedTime();
                }
                Destroy(gameObject);
            }
        }
    }
}
