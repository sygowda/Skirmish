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
        GameObject player2 = GameObject.FindGameObjectWithTag("Player2Tag");
        if (Time.time > nextActionTime)
        {
            player2.GetComponent<Renderer>().material.color = new Color(1f, 1f, 1f);
            if (p2Touch.p2_touch.phase != TouchPhase.Ended && Camera.main.ScreenToWorldPoint(p2Touch.p2_touch.position).y < -2.5f)
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
                    
                    player2.GetComponent<Renderer>().material.color = new Color(0.5f, 0.5f, 0.5f);
                }


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
