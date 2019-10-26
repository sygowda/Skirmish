using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class p2Touch : MonoBehaviour
{
    public Transform cursorObject;
    public float distance = 1.5f;
    public bool drag = false;
    public static Touch p2_touch;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        foreach (Touch touch in Input.touches)
        {
            if (touch.phase == TouchPhase.Began && Camera.main.ScreenToWorldPoint(touch.position).y < 0f)
            {
                p2_touch = touch;
            }
        }

        Ray ray = Camera.main.ScreenPointToRay(p2_touch.position);
        Vector3 point = transform.position;
        point.x = ray.origin.x + (ray.direction.x * distance);
        //if (Camera.main.ScreenToWorldPoint(Input.mousePosition).y < 0f)
        //{
            if (point.x > 2.553f) { point.x = 2.553f; }
            if (point.x < -2.553f) { point.x = -2.553f; }

            if (drag)
                cursorObject.position = point;

            if (p2_touch.phase == TouchPhase.Ended || p2_touch.phase == TouchPhase.Canceled)
            {
                drag = false;
            }
            else
            {
                drag = true;
            }

        //}
    }
}
