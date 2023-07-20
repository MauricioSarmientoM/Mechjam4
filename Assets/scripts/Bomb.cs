using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour
{
    public GameObject explosion;
    public int damage = 3;
    public float radius = 5;
    public float timer = 3;
    public LayerMask layerMask;
    public Rigidbody rigid;
    public float speed;
    void Start() {
        rigid.velocity = Player.player.transform.forward * speed;
    }
    private void FixedUpdate() {
        timer -= Time.deltaTime;
        transform.rotation = Quaternion.LookRotation(transform.position - Player.player.transform.position);
    }
    private void OnTriggerEnter(Collider other) {
        
    }
    public void Explode() {
        Destroy(Instantiate(explosion, transform.position, transform.rotation), .5f);
        RaycastHit[] targets = Physics.SphereCastAll(transform.position, radius, Vector3.up, 10, layerMask);
        for (int i = 0; i < targets.Length; i++) targets[i].collider.GetComponent<Enemy>()?.TakeDamage(damage);
        Destroy(gameObject);
    }
}
