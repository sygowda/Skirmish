using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpecialBulletKill : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D collision)
    {
        BulletSpecial bullet = collision.GetComponent<BulletSpecial>();
        if (bullet != null)
        {
            Destroy(gameObject);
        }

    }
}
