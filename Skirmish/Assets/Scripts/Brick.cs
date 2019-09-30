using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Brick : MonoBehaviour
{
    public int weight = 0;
    // Start is called before the first frame update
    void Start()
    {
        System.Random rand = new System.Random();
        weight = rand.Next(10, 100);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TakeDamage( int damage)
    {
        weight -= damage;
        if(weight <= 0)
        {
            Break();
        }
    }
    private void Break()
    {
        Destroy(gameObject);
    }
}
