using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public Rigidbody rigid;
    public float speed;
    public float maxSpeed;
    public int life;
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
        if (Vector3.Distance(transform.position, player.transform.position) > 30) animator.SetTrigger("Death");
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
        Destroy(gameObject);
    }
}
