using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingS : MonoBehaviour
{
    public Transform firePoint;
    public GameObject LazerPrefab;

    public float bulletForce =20f;

    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }
    }

    void Shoot(){
        GameObject Lazer = Instantiate(LazerPrefab,firePoint.position,firePoint.rotation);
        Rigidbody2D rb = Lazer.GetComponent<Rigidbody2D>();
        rb.AddForce(firePoint.up*bulletForce,ForceMode2D.Impulse);
    }
}

