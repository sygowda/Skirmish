﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class P1Weapon : MonoBehaviour
{
    public Transform firePoint;
    public GameObject bulletPrefab;

    public float nextActionTime = 0.0f;
    public float period = 0.2f;
    public int max_shots = 10;
    public int cur_shots;
    public float cd_time = 2;
    Transform bulletBar;

    private void Start()
    {
        bulletBar = transform.Find("BulletCountBar1");
        setBulletBarSize(1f);
    }



    // Update is called once per frame
    void Update()
    {
        if (GameController.instance.startGame == false) return;
        GameObject player1 = GameObject.FindGameObjectWithTag("Player1Tag");
        if (Time.time > nextActionTime)
        {
            player1.GetComponent<Renderer>().material.color = new Color(1f, 1f, 1f);
            //Debug.Log("P1 y position: " + Camera.main.ScreenToWorldPoint(p1Touch.p1_touch.position).y);
            if (p1Touch.p1_touch.phase != TouchPhase.Ended && Camera.main.ScreenToWorldPoint(p1Touch.p1_touch.position).y > 2.5f)
            {
                if (cur_shots == 0)
                {
                    cur_shots = max_shots;
                }
                setBulletBarSize((float)cur_shots / max_shots);
                Shoot();
                nextActionTime += period;
                cur_shots--;
                if (cur_shots == 0)
                {
                    nextActionTime += cd_time;
                    player1.GetComponent<Renderer>().material.color = new Color(0.5f, 0.5f, 0.5f);
                    setBulletBarSize(0f);
                }
            }
        }
    }

    void Shoot()
    {
        if (GameController.instance.gameOver != true)
        {
            Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        }
    }

    public void setBulletBarSize(float normalizedSize)
    {
        if (normalizedSize > 0.3)
        {
            bulletBar.Find("BulletCount1").GetComponent<Renderer>().material.color = new Color(0.31f, 0.77f, 0.26f);
        }
        else
        {
            bulletBar.Find("BulletCount1").GetComponent<Renderer>().material.color = new Color(0.66f, 0.77f, 0.65f);
        }
        bulletBar.localScale = new Vector2(bulletBar.localScale.x, normalizedSize);
    }
}
