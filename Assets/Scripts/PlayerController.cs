using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public float speed = 7f;
    private CharacterController controller;


    public void Start()
    {
        controller = GetComponent<CharacterController>();
    }

	

    void Update()
    {
        Vector3 dir = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical"));

        if (dir.z != 0)
            dir.x = 0;
        controller.Move(dir * speed * Time.deltaTime);

        if (dir.z > 0)
            transform.rotation = Quaternion.Euler(0, 0, 0);
        else if (dir.z < 0)
            transform.rotation = Quaternion.Euler(0, 180, 0);
        else if (dir.x > 0)
            transform.rotation = Quaternion.Euler(0, 90, 0);
        else if (dir.x < 0)
            transform.rotation = Quaternion.Euler(0, -90, 0);
    }
}
