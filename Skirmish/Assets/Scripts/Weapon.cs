using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public Transform firePoint;
    public GameObject bulletPrefab;
    public float nextActionTime = 0.0f;
    public float period = 0.1f;
    public int max_shots = 20;
    public int cur_shots;
    public float cd_time = 2;
    Transform bulletBar;
    private float elapsedTimeSinceStart;
    private int cnt = 0;
    private int cd_cnt = 0;
    public int max_cnt = 2;
    public int max_cd_cnt = 100;
    GameObject player2;

    private void Start()
    {
        bulletBar = transform.Find("BulletCountBar");
        setBulletBarSize(1f);
        p2Touch.p2_touch.phase = TouchPhase.Ended;
        player2 = GameObject.FindGameObjectWithTag("Player2Tag");
    }

    // Update is called once per frame
    void Update()
    {

        if (cd_cnt >= 0)
        {
            cd_cnt--;
            return;
        }
        if (cnt >= 0)
        {
            cnt--;
            return;
        }
        player2.GetComponent<Renderer>().material.color = new Color(1f, 1f, 1f);
        if (p2Touch.p2_touch.phase != TouchPhase.Ended && Camera.main.ScreenToWorldPoint(p2Touch.p2_touch.position).y < 2.5f)
        {

            if (cur_shots == 0)
            {
                cur_shots = max_shots;

            }
            setBulletBarSize((float)cur_shots / max_shots);
            Shoot();
            cnt = max_cnt;
            cur_shots--;
            if (cur_shots == 0)
            {
                cd_cnt = max_cd_cnt;
                AnalyticsManager.increaseCoolDownCount(0);
                player2.GetComponent<Renderer>().material.color = new Color(0.5f, 0.5f, 0.5f);
                setBulletBarSize(0f);
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
            bulletBar.Find("BulletCount").GetComponent<Renderer>().material.color = new Color(0.31f, 0.77f, 0.26f);
        }
        else
        {
            bulletBar.Find("BulletCount").GetComponent<Renderer>().material.color = new Color(0.66f, 0.77f, 0.65f);
        }
        bulletBar.localScale = new Vector2(bulletBar.localScale.x, normalizedSize);
    }
}
