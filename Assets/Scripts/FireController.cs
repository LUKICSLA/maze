using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireController : MonoBehaviour
{

    //public float projectileSpeed = 13f;
    public GameObject bullet;
    public Transform placeToFire;

    void Update()
    {
        if (Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.Space))
            Fire();
    }

    private void Fire()
    {
        Instantiate(bullet, placeToFire.position, transform.rotation);
    }
}
