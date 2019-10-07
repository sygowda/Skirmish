using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowBulletStatus : MonoBehaviour
{
    private Weapon player;
    private Text display;
    private Text cd;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player1").GetComponent<Weapon>();
        display = GameObject.Find("BulletText").GetComponent<Text>();
        cd = GameObject.Find("CDText").GetComponent<Text>();

    }

    // Update is called once per frame
    void Update()
    {
        display.text = "Bullet: "+player.cur_shots.ToString();
        if (player.cur_shots == 0)
            cd.text = "cd: " + System.Math.Round((player.nextActionTime- Time.time),2).ToString();
        else
            cd.text = "";
          
    }
}
