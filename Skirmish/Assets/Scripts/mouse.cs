﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mouse : MonoBehaviour
{
    public Transform cursorObject;
    public float distance = 1.5f;
    public bool drag = false;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        Vector3 point = transform.position;
            point.x = ray.origin.x + (ray.direction.x * distance);
        if(drag)
            cursorObject.position = point;
        if (Input.GetMouseButtonDown(0))
            drag = true;
        if (Input.GetMouseButtonUp(0))
            drag = false;


    }
}