using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public Rigidbody rigid;
    public float speed;
    public float maxSpeed;
    public int life;
    void FixedUpdate() 
    {
        Vector3 direction = Player.player.transform.position - transform.position;

        direction = direction.normalized * speed;
        rigid.velocity = new(Mathf.Clamp(rigid.velocity.x + direction.x, -maxSpeed, maxSpeed),
                             Mathf.Clamp(rigid.velocity.y + direction.y, -maxSpeed, maxSpeed),
                             Mathf.Clamp(rigid.velocity.z + direction.z, -maxSpeed, maxSpeed));

        transform.rotation = Quaternion.LookRotation(transform.position - Player.player.transform.position);
    }

    public void TakeDamage(int damage)
    {
        life -= damage;

        if (life <= 0)
        {
            Destroy(gameObject);
        }
    }
}
