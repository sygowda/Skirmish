using System.Collections;

public class shooting : MonoBehaviour
{
    public Transform firePoint;
    public GameObject bulletPrefab;

    void Update()
    {
        //fire1 button needs to be determined
        if (Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }
    }

    void shoot()
    {
        //shooting logic
        Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);

    }
}