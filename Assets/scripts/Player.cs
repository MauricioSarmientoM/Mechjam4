using UnityEngine;
using UnityEngine.UI;
public class Player : MonoBehaviour
{
    public Rigidbody rigid;
    public float speed = 2;
    public Vector3 velocity;
    public float smoothFactor;
    void Start() {
        
    }
    void Update() {
        Movement();
    }
    void FixedUpdate() {
        rigid.velocity = Vector3.Lerp(rigid.velocity, velocity, smoothFactor);
    }
    void Movement() {
        velocity = Vector3.zero;
        //if ()
    }
}