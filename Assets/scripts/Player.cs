using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Rigidbody rigid;
    public float speed;
    public float maxSpeed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
    }
    public void Movement()
    {
        Vector3 movement = Vector3.zero;
        if (Input.GetKey(KeyCode.W))
        {
            movement.z = Mathf.Clamp(movement.z + Mathf.Cos(transform.rotation.y * Mathf.Deg2Rad), -1, 1);
            movement.x = Mathf.Clamp(movement.x + Mathf.Sin(transform.rotation.y * Mathf.Deg2Rad), -1, 1);
        }
        if (Input.GetKey(KeyCode.S))
            movement.z = Mathf.Clamp(movement.z - 1, -1, 1);
        if (Input.GetKey(KeyCode.A))
            movement.x = Mathf.Clamp(movement.x - 1, -1, 1);
        if (Input.GetKey(KeyCode.D))
            movement.x = Mathf.Clamp(movement.x + 1, -1, 1);

        movement = movement.normalized * speed;
        rigid.velocity = new(Mathf.Clamp(rigid.velocity.x + movement.x, -maxSpeed, maxSpeed),
                             Mathf.Clamp(rigid.velocity.y + movement.y, -maxSpeed, maxSpeed),
                             Mathf.Clamp(rigid.velocity.z + movement.z, -maxSpeed, maxSpeed));

    }
}
