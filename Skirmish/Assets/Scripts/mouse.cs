using System.Collections;
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
        if (GameController.instance.startGame == false) return;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        Vector3 point = transform.position;
        point.x = ray.origin.x + (ray.direction.x * distance);
        if (Camera.main.ScreenToWorldPoint(Input.mousePosition).y < 0f)
        {
            if (point.x > 2.553f) { point.x = 2.553f; }
            if (point.x < -2.553f) { point.x = -2.553f; }

            if (drag)
                cursorObject.position = point;
            if (Input.GetMouseButtonDown(0))
                drag = true;
            if (Input.GetMouseButtonUp(0))
                drag = false;

        }
    }
}
