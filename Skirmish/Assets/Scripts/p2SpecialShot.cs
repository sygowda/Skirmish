﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class p2SpecialShot : MonoBehaviour
{
    private int p2numShots = 1;
    public Transform firePoint;
    public GameObject bulletPrefab;

    // Start is called before the first frame update
    void Start()
    {
        
        
    }

    public void ShootSpecial()
    {
        Debug.Log("special shot button pressed");
        if (p2numShots > 0) //GameController.instance.gameOver != true &&
        {
            Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
            p2numShots--;
        }
        
    }
}


