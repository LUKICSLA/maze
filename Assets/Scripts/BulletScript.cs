using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{

    public float speed = 13f;

    // Use this for initialization
    void Start()
    {
        Destroy(gameObject, 20f);
    }
	
    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }
}
