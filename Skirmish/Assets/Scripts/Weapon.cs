using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public Transform firePoint;
    public GameObject bulletPrefab;

    public float nextActionTime = 0.0f;
    public float period = 0.1f;
    public int max_shots = 10;
    public int cur_shots;
    public float cd_time = 2;

    // Update is called once per frame
    void Update()
    {
        //if (Input.GetButtonDown("Fire1"))
        //{
        // Shoot();
        //}
        if (Time.time > nextActionTime && Camera.main.ScreenToWorldPoint(Input.mousePosition).y < -2.5f)
        {
            if (cur_shots == 0)
            {
                cur_shots = max_shots;
            }
            Shoot();
            nextActionTime = nextActionTime + period;
            cur_shots--;
            if (cur_shots == 0)
            {
                nextActionTime = nextActionTime + cd_time;
            }
            
                
        }
    }

    void Shoot()
    {
        if(GameController.instance.gameOver != true)
        {
            Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        }
    }
}
