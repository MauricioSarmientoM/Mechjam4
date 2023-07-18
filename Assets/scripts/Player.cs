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
    public RectTransform movementMaster;
    public Image[] movementIndicator;
    [Header("SFX")]
    public AudioSource jet;
    [Header("Stats")]
    public int health;
    public int shield;
    public int energy;
    // Start is called before the first frame update
    void Awake()
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
    private void FixedUpdate() {
        movementMaster.localRotation = transform.rotation;
        movementIndicator[0].fillAmount = Mathf.Clamp(rigid.velocity.y / maxSpeed, 0, 1);
        movementIndicator[1].fillAmount = -Mathf.Clamp(rigid.velocity.y / maxSpeed, -1, 0);
        movementIndicator[2].fillAmount = Mathf.Clamp(rigid.velocity.x / maxSpeed, 0, 1);
        movementIndicator[3].fillAmount = -Mathf.Clamp(rigid.velocity.x / maxSpeed, -1, 0);
        movementIndicator[4].fillAmount = Mathf.Clamp(rigid.velocity.x / maxSpeed, 0, 1);
        movementIndicator[5].fillAmount = -Mathf.Clamp(rigid.velocity.x / maxSpeed, -1, 0);
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.Space) || Input.GetKey(KeyCode.LeftShift))
            jet.volume = Mathf.Clamp(jet.volume + .02f, 0, .4f);
        else jet.volume = Mathf.Clamp(jet.volume - .04f, 0, .4f);
            
    }
    public void Movement()
    {
        movement = 
            (Input.GetKey(KeyCode.A) ? -transform.right : Vector3.zero) + 
            (Input.GetKey(KeyCode.D) ? transform.right : Vector3.zero) +
            (Input.GetKey(KeyCode.W) ? transform.forward : Vector3.zero) + 
            (Input.GetKey(KeyCode.S) ? -transform.forward : Vector3.zero) + 
            (Input.GetKey(KeyCode.Space) ? transform.up : Vector3.zero) + 
            (Input.GetKey(KeyCode.LeftShift) ? -transform.up : Vector3.zero);
    
        movement = movement.normalized * speed;
        rigid.velocity = new(Mathf.Clamp(rigid.velocity.x + movement.x, -maxSpeed, maxSpeed),
                             Mathf.Clamp(rigid.velocity.y + movement.y, -maxSpeed, maxSpeed),
                             Mathf.Clamp(rigid.velocity.z + movement.z, -maxSpeed, maxSpeed));

    }
}