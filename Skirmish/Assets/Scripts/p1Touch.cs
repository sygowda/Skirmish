using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class p1Touch : MonoBehaviour
{
    public Transform cursorObject;
    public float distance = 1.5f;
    public bool drag = false;
    public static Touch p1_touch;


    // Update is called once per frame
    void Update()
    {
        if (GameController.instance.startGame == false)
        {
            p1_touch.position = new Vector2(0f, 1f);
            return;
        }
        var numTouches = Input.touchCount;
        for (int i = 0; i < numTouches; i++)
        {
            Touch thisTouch = Input.GetTouch(i);
            //Debug.Log("touch at position: " + Camera.main.ScreenToWorldPoint(thisTouch.position));
            if (Camera.main.ScreenToWorldPoint(thisTouch.position).y > 0f)
            {
                p1_touch = thisTouch;
            }
        }

        //Ray ray = Camera.main.ScreenPointToRay(p2_touch.position);
        Vector3 point = Camera.main.ScreenToWorldPoint(p1_touch.position);
        point.z = 0;
        point.y = 2;
        //point.x = ray.origin.x + (ray.direction.x * distance);
        //if (Camera.main.ScreenToWorldPoint(Input.mousePosition).y < 0f)
        //{
        //if (point.x > 2.553f) { point.x = 2.553f; }
        //if (point.x < -2.553f) { point.x = -2.553f; }

        if (p1_touch.phase == TouchPhase.Moved)
        {
            cursorObject.position = point;
            Debug.Log("moved to position: " + point);
        }
        //if (p2_touch.phase == TouchPhase.Ended || p2_touch.phase == TouchPhase.Canceled)
        //{
        //    drag = false;
        //}
        //else
        //{
        //    drag = true;
        //}

        //}
    }
}
