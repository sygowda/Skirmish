using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class chest_movement : MonoBehaviour
{
    public float x_speed = 1.5f;
    public bool outsideBounds = false;

    // Start is called before the first frame update
    void Start()
    {
        if (GetComponent<Rigidbody2D>().position.x < 0)
        {
            x_speed = -x_speed;
        }
        GetComponent<Rigidbody2D>().velocity = new Vector2(x_speed, 0);
    }

    // Update is called once per frame
    void Update()
    {
        float x_pos = GetComponent<Rigidbody2D>().position.x;

        if (System.Math.Abs(x_pos) >= 2.5f && !outsideBounds)
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(-x_speed, 0);
            x_speed = -x_speed;
            outsideBounds = true;
        } else if (System.Math.Abs(x_pos) <= 2.5f)
        {
            outsideBounds = false;
        }
        
    }
}
