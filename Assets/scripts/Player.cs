using UnityEngine;
using UnityEngine.UI;
public class Player : MonoBehaviour
{
    public Rigidbody rigid;
    public float speed;
    public float maxSpeed;
    public Vector3 movement;
    public static Player player;
    [Header("UI")]
    public Image healthGauge;
    public Image shieldGauge;
    public Image energyGauge;
    // Start is called before the first frame update
    void Start()
    {
        if (player == null)
        {
            player = this;
        }
        else if (player != this)
        {
            Destroy(gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
    }
    public void Movement()
    {
        movement = 
            (Input.GetKey(KeyCode.A) ? -transform.right : Vector3.zero) + 
            (Input.GetKey(KeyCode.D) ? transform.right : Vector3.zero) +
            (Input.GetKey(KeyCode.W) ? transform.forward : Vector3.zero) + 
            (Input.GetKey(KeyCode.S) ? -transform.forward : Vector3.zero);
    
        movement = movement.normalized * speed;
        rigid.velocity = new(Mathf.Clamp(rigid.velocity.x + movement.x, -maxSpeed, maxSpeed),
                             Mathf.Clamp(rigid.velocity.y + movement.y, -maxSpeed, maxSpeed),
                             Mathf.Clamp(rigid.velocity.z + movement.z, -maxSpeed, maxSpeed));

    }
}