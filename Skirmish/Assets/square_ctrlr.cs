using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class square_ctrlr : MonoBehaviour
{
    public float maxSpeed = 10f;
    Animator a;
    // Start is called before the first frame update
    void Start()
    {
        a = GetComponent<Animator>();
        
    }

    // Update is called once per frame
    void Update()
    {
        float move = Input.GetAxis("Horizontal");
        GetComponent<Rigidbody2D>().velocity = new Vector3(move * maxSpeed, GetComponent<Rigidbody2D>().velocity.y);
        a.SetFloat("Speed", Mathf.Abs(move));
    }
}
