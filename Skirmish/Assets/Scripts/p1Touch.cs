﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class p1Touch : MonoBehaviour
{
    public Transform p1cursorObject;
    public float p1distance = 1.5f;
    public bool p1drag = false;
    public static Touch p1_touch;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        foreach (Touch touch in Input.touches) {
            if (Camera.main.ScreenToWorldPoint(touch.position).y > 0f)
            {
                p1_touch = touch;
            }
        }
        //Ray ray = Camera.main.ScreenPointToRay(p1_touch.position);
        Vector3 point = Camera.main.ScreenToWorldPoint(p1_touch.position);
        point.z = 0;
        point.y = 2;
        //point.x = ray.origin.x + (ray.direction.x * p1distance);
        //if (Camera.main.ScreenToWorldPoint(Input.GetTouch(0).position).y > 0f)
        //{
        //if (point.x > 2.553f) { point.x = 2.553f; }
        //if (point.x < -2.553f) { point.x = -2.553f; }

        //    if (p1_touch.phase == TouchPhase.Began)
        //{
        //    p1cursorObject.position = new Vector3 (p1_touch.position.x, p1cursorObject.position.y, p1cursorObject.position.z);
        //}

        if (p1_touch.phase == TouchPhase.Moved)
            p1cursorObject.position = point;

            //if (p1_touch.phase == TouchPhase.Ended || p1_touch.phase == TouchPhase.Canceled)
            //{
            //    p1drag = false;
            //} else
            //{
            //    p1drag = true;
            //}                
        //}
        //if (p1_touch.phase == TouchPhase.Ended)
        //{
        //    p1cursorObject.Translate(0, 0, 0);
        //}
    }
}

