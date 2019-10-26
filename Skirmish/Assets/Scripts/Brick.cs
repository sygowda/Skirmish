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
        weight = Random.Range(5, 40);
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
        Vector2 p = this.transform.position;
        print(p);
        GameController.instance.availableBrickPositions.Add(p);
        Destroy(gameObject);
    }


    private void SetColor()
    {
        if (weight >= 35)
        {
            currentColor = highPlus;
        }
        else if(weight < 35 && weight >= 25)
        {
            currentColor = high;
        }
        else if (weight < 25 && weight >= 20)
        {
            currentColor = mediumPlus;
        }
        else if (weight < 20 && weight >= 15)
        {
            currentColor = medium;
        }
        else if (weight < 15 && weight >= 10)
        {
            currentColor = lowPlus;
        }
        else if (weight < 10)
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
