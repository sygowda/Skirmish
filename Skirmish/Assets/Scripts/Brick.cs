using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Brick : MonoBehaviour
{
    public int weight = 0;
    private Color highPlus = new Color(0f, 0f, 0f);
    private Color high = new Color(0.5f, 0.08f, 0f);
    private Color mediumPlus = new Color(0.6603774f, 0.2013205f, 0.1214845f);
    private Color medium = new Color(0.8679245f, 0.3749432f, 0.2906728f);
    private Color lowPlus = new Color(0.8018868f, 0.6571488f, 0.631675f);
    private Color low = new Color(1f,1f,1f);
    Color currentColor;
    Renderer renderer;


    void Awake()
    {
        weight = Random.Range(3, 30);
        renderer = GetComponent<Renderer>();
        SetColor();
        renderer.material.color = currentColor;
    }
    void Start()
    { 

    }

    public void TakeDamage(int damage)
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
        gameObject.SetActive(false);
        weight = Random.Range(3, 30);
        SetColor();
        renderer.material.color = currentColor;
    }


    private void SetColor()
    {
        if (weight >= 25)
        {
            currentColor = highPlus;
        }
        else if(weight < 25 && weight >= 20)
        {
            currentColor = high;
        }
        else if (weight < 20 && weight >= 15)
        {
            currentColor = mediumPlus;
        }
        else if (weight < 15 && weight >= 10)
        {
            currentColor = medium;
        }
        else if (weight < 10 && weight >= 5)
        {
            currentColor = lowPlus;
        }
        else if (weight < 5)
        {
            currentColor = low;
        }
    }

    private void ChangeColor()
    {
        SetColor();
        renderer.material.color = Color.Lerp(renderer.material.color, currentColor, 0.1f);
    }
}
