using UnityEngine;
using UnityEngine.UI;
using System.Collections;
public class Player : MonoBehaviour
{
    public Rigidbody rigid;
    public float speed;
    public float maxSpeed;
    public Vector3 movement;
    public static Player player;
    public GameObject bomb;
    [Header("UI")]
    public Image healthGauge;
    public Image shieldGauge;
    public Image energyGauge;
    public Text healthText;
    public Text shieldText;
    public Text energyText;
    public RectTransform movementMaster;
    public Image[] movementIndicator;
    public Image blindness;
    public Animator portrait;
    [Header("SFX")]
    public AudioSource jet;
    public AudioLowPassFilter ost;
    //public AudioSource tinnitus;
    [Header("Stats")]
    public int health;
    public int shield;
    public int energy;
    public int points;
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
    private void Start() {
        StartCoroutine(Recharge());
        healthText.text = $"{health}";
        shieldText.text = $"{shield}";
        energyText.text = $"{energy}";
    }
    // Update is called once per frame
    void Update()
    {
        Movement();
        if (Input.GetKeyDown(KeyCode.Mouse1) && energy > 33) {
            Instantiate(bomb, transform);
            energy -= 33;
            energyGauge.fillAmount = energy / 100f;
            energyText.text = $"{energy}";
        }
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
    public void TakeDamage(int damage)
    {
        int shieldBefore = shield;
        shield = Mathf.Clamp(shield - damage, 0, 100);
        health = Mathf.Clamp(health - (damage - Mathf.RoundToInt(damage * (shieldBefore / 100f))), 0, 100);
        //tinnitus.volume = Mathf.Clamp01(.05f - (health / 1000f));
        blindness.color = new(1, 1, 1, Mathf.Clamp01(1 - (health / 100f)));
        ost.cutoffFrequency = 100 + (20000 * (health / 100f));
        healthGauge.fillAmount = health / 100f;
        healthText.text = $"{health}";
        shieldGauge.fillAmount = shield / 100f;
        shieldText.text = $"{shield}";
        if (health <= 0)
        {
            portrait.SetTrigger("Death");
        }
    }
    IEnumerator Recharge() {
        for ( ; ; ) {
            yield return new WaitForSeconds(1);
            shield = Mathf.Clamp(shield + 1, 0, 100);
            energy = Mathf.Clamp(energy + 1, 0, 100);
            shieldGauge.fillAmount = shield / 100f;
            shieldText.text = $"{shield}";
            energyGauge.fillAmount = energy / 100f;
            energyText.text = $"{energy}";
        }
    }
}