using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class p2SpecialShot : MonoBehaviour
{
    private int numShots = 1;
    public Transform firePoint;
    public GameObject bulletPrefab;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void ShootSpecial()
    {
        if (GameController.instance.gameOver != true && numShots > 0)
        {
            Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
            numShots--;
        }
    }
}


