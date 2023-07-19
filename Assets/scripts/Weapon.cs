using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public Animator animator;
    public int damage;
    private Collider player;
    public LayerMask layerMask;
    private void Start() 
    {
        player = Player.player.GetComponent<Collider>();
    }
    // Update is called once per frame
    void Update()
    {
        Attack();
    }

    public void Attack()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            animator.SetTrigger("Attack");
        }
    }

    public void Revolver()
    {
        RaycastHit[] enemy = Physics.RaycastAll(player.transform.position, player.transform.forward, 500, layerMask);
        if (enemy.Length > 0) {
            enemy[0].collider.GetComponent<Enemy>()?.TakeDamage(damage);
        }
    }
}
