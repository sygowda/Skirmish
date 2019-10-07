using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Brick : MonoBehaviour
{
    public int weight = 0;
    private Color high = Color.red, low = Color.green, mediumPlus = Color.blue, medium = Color.cyan;
    Color currentColor;
    Renderer renderer;


    void Awake()
    {
        System.Random rand = new System.Random();
        weight = rand.Next(10, 40);
        renderer = GetComponent<Renderer>();
        SetColor();
        renderer.material.color = currentColor;
    }
    void Start()
    { 

    }

    void Update()
    {
         /*if(Input.GetKeyDown(KeyCode.Space))
        {
            if(currentColor == high)
            {
                currentColor = low;
            } else
            {
                currentColor = high;
            }
        }

        renderer.material.color = Color.Lerp(renderer.material.color, currentColor, 0.1f);*/
    }

    public void TakeDamage( int damage)
    {
        weight -= damage;
        if(weight <= 0)
        {
            Break();
        }
        ChangeColor();
    }

    private void Break()
    {
        Destroy(gameObject);
    }


    private void SetColor()
    {
        if (weight >= 35)
        {
            currentColor = high;
        }
        else if (weight >= 25)
        {
            currentColor = mediumPlus;
        }
        else if (weight >= 15)
        {
            currentColor = medium;
        }
        else
        {
            currentColor = low;
        }
    }

    private void ChangeColor()
    {
        SetColor();
        renderer.material.color = Color.Lerp(renderer.material.color, currentColor, 0.2f);
    }
}
