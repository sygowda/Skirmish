using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Weapon : MonoBehaviour
{
    public Transform firePoint;
    public GameObject bulletPrefab;
    //public GameObject bulletDisplay;
    //public GameObject cooldownDisplay;
    GameObject player2;

    public float nextActionTime = 0.0f;
    public float period = 0.1f;
    public int max_shots = 10;
    public int cur_shots;
    public float cd_time = 2;

    private void Start()
    {
        player2 = GameObject.FindGameObjectWithTag("Player2Tag");
    }
    // Update is called once per frame
    void Update()
    {
        //bulletDisplay.GetComponent<Text>().text = cur_shots.ToString();

        
        if (Time.time > nextActionTime)
        {

            player2.GetComponent<Renderer>().material.color = new Color(1f, 1f, 1f);
            if (p2Touch.p2_touch.phase != TouchPhase.Ended && Camera.main.ScreenToWorldPoint(p2Touch.p2_touch.position).y < 2.5f)
            {


                
                Shoot();
                nextActionTime = nextActionTime + period;
                cur_shots--;
                if (cur_shots == -1)
                {
                    
                    nextActionTime = nextActionTime + cd_time;
                    player2.GetComponent<Renderer>().material.color = new Color(0.5f, 0.5f, 0.5f);

                }


            }
            else
            {
               
            }
        }
        else
        {
            //cooldownDisplay.GetComponent<Text>().text = (nextActionTime - Time.time).ToString();
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
