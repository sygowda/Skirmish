﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class p1Weapon : MonoBehaviour
{
    public Transform p1_firePoint;
    public GameObject p1_bulletPrefab;

    public float p1_nextActionTime = 0.0f;
    public float p1_period = 0.1f;
    public int p1_max_shots = 10;
    public int p1_cur_shots;
    public float p1_cd_time = 2;

    void P1Shoot()
    {
        if (GameController.instance.gameOver != true)
        {
            Instantiate(p1_bulletPrefab, p1_firePoint.position, p1_firePoint.rotation);
        }
    }

    // Update is called once per frame
    void Update()
    {
        //if (Input.GetButtonDown("Fire1"))
        //{
        // Shoot();
        //}
        if (Time.time > p1_nextActionTime && Input.GetKey(KeyCode.DownArrow))
        {
            if (p1_cur_shots == 0)
            {
                p1_cur_shots = p1_max_shots;
            }
            P1Shoot();
            p1_nextActionTime = p1_nextActionTime + p1_period;
            p1_cur_shots--;
            if (p1_cur_shots == 0)
            {
                p1_nextActionTime = p1_nextActionTime + p1_cd_time;
            }


        }
    }

    
}

