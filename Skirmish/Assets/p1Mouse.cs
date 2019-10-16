using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class p1Mouse : MonoBehaviour
{
    public Transform p1cursorObject;
    public float p1distance = 1.5f;
    public bool p1drag = false;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        Vector3 point = transform.position;
        point.x = ray.origin.x + (ray.direction.x * p1distance);
        if (Camera.main.ScreenToWorldPoint(Input.mousePosition).y > 0f)
        {
            if (point.x > 2.553f) { point.x = 2.553f; }
            if (point.x < -2.553f) { point.x = -2.553f; }

            if (p1drag)
                p1cursorObject.position = point;
            if (Input.GetMouseButtonDown(0))
                p1drag = true;
            if (Input.GetMouseButtonUp(0))
                p1drag = false;

        }
    }
}


