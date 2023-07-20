using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public Rigidbody rigid;
    public float speed;
    public float maxSpeed;
    public int damage;
    public float cooldown;
    public int life;
    public float duration = 30;
    public Animator animator;
    private Collider player;
    private void Start()
    {
        player = Player.player.GetComponent<Collider>();
    }
    void FixedUpdate()
    {
        Vector3 direction = player.transform.position - transform.position;

        direction = direction.normalized * speed;
        rigid.velocity = new(Mathf.Clamp(rigid.velocity.x + direction.x, -maxSpeed, maxSpeed),
                             Mathf.Clamp(rigid.velocity.y + direction.y, -maxSpeed, maxSpeed),
                             Mathf.Clamp(rigid.velocity.z + direction.z, -maxSpeed, maxSpeed));

        transform.rotation = Quaternion.LookRotation(transform.position - player.transform.position);
        duration -= Time.deltaTime;
        if (Vector3.Distance(transform.position, player.transform.position) > 30 || duration < 0) animator.SetTrigger("Death");
        cooldown -= Time.deltaTime;
        if (Vector3.Distance(transform.position, player.transform.position) < 2 && cooldown < 0) {
            Player.player.TakeDamage(damage);
            cooldown = 1;
        }
    }
    public void TakeDamage(int damage)
    {
        life -= damage;

        if (life <= 0)
        {
            animator.SetTrigger("Death");
        }
    }
    public void KYS() {
        EnemySpawner.spawner.amount--;
        Player.player.points++;
        Destroy(gameObject);
    }
    public void KYSNoPoints() {
        EnemySpawner.spawner.amount--;
        Destroy(gameObject);
    }
    IEnumerable AutoKYS() {
        yield return new WaitForSeconds(20);
        KYSNoPoints();
    }
}
