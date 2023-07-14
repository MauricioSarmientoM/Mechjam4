using UnityEngine;
public class Player : MonoBehaviour
{
    public Rigidbody rigid;
    public float speed;
    public float maxSpeed;
    public Vector3 movement;
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
        movement = new((Input.GetKey(KeyCode.A) ? -1 : 0) + (Input.GetKey(KeyCode.D) ? 1 : 0),
                        0,
                        (Input.GetKey(KeyCode.W) ? 1 : 0) + (Input.GetKey(KeyCode.S) ? -1 : 0));
        movement = new(movement.x * Mathf.Sin(transform.rotation.y) + movement.z * Mathf.Sin(transform.rotation.y),
                       0,
                       movement.z * Mathf.Cos(transform.rotation.y) + movement.x * Mathf.Cos(transform.rotation.y));
        /* if (Input.GetKey(KeyCode.W))
        {
            movement.z = Mathf.Clamp(movement.z + Mathf.Cos(transform.rotation.y * Mathf.Deg2Rad), -1, 1);
            movement.x = Mathf.Clamp(movement.x - Mathf.Sin(transform.rotation.y * Mathf.Deg2Rad), -1, 1);
        }
        if (Input.GetKey(KeyCode.S))
        {
            movement.z = Mathf.Clamp(movement.z - Mathf.Cos(transform.rotation.y * Mathf.Deg2Rad), -1, 1);
            movement.x = Mathf.Clamp(movement.x + Mathf.Sin(transform.rotation.y * Mathf.Deg2Rad), -1, 1);
        }
        if (Input.GetKey(KeyCode.A))
        {
            movement.z = Mathf.Clamp(movement.z - Mathf.Sin(transform.rotation.y * Mathf.Deg2Rad), -1, 1);
            movement.x = Mathf.Clamp(movement.x - Mathf.Cos(transform.rotation.y * Mathf.Deg2Rad), -1, 1);
        }
        if (Input.GetKey(KeyCode.D))
        {
            movement.z = Mathf.Clamp(movement.z + Mathf.Sin(transform.rotation.y * Mathf.Deg2Rad), -1, 1);
            movement.x = Mathf.Clamp(movement.x + Mathf.Cos(transform.rotation.y * Mathf.Deg2Rad), -1, 1);
        } */
        movement = movement.normalized * speed;
        rigid.velocity = new(Mathf.Clamp(rigid.velocity.x + movement.x, -maxSpeed, maxSpeed),
                             Mathf.Clamp(rigid.velocity.y + movement.y, -maxSpeed, maxSpeed),
                             Mathf.Clamp(rigid.velocity.z + movement.z, -maxSpeed, maxSpeed));

    }
}

/**
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Rigidbody rb;
    Vector2 inputMov;
    Vector2 inputRot;
    public float velCaminata = 10f;
    public float velCorrer = 20f;
    public float mouseSensivity = 1;
    Transform cam;
    float rotX;
    
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        cam = transform.GetChild(0);
        rotX = cam.eulerAngles.x;
    }

    // Update is called once per frame
    void Update()
    {
        //Leemos el input
        inputMov.x = Input.GetAxis("Horizontal");
        inputMov.y = Input.GetAxis("Vertical");

        inputRot.x = Input.GetAxis("Mouse X") * mouseSensivity;
        inputRot.y = Input.GetAxis("Mouse Y") * mouseSensivity;
    }

    public void FixedUpdate()
    { //Usamos ese input para movernos y girar
        float vel = Input.GetKey(KeyCode.LeftShift) ? velCorrer : velCaminata;

        rb.velocity = 
            transform.forward * vel * inputMov.y    //Movernos hacia atrás y adelante
            + transform.right * vel * inputMov.x    //Movernos hacia los costados
            + new Vector3 (0, rb.velocity.y, 0);    //Permitir que la gravedad haga efecto

        transform.rotation *= Quaternion.Euler(0, inputRot.x, 0);  //Rotar horizontal

        rotX -= inputRot.y;
        rotX = Mathf.Clamp(rotX, -50, 50);
        cam.localRotation = Quaternion.Euler(rotX, 0, 0);
    }
}
**/