using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public Animator animator;
    public int damage;
    private Collider player;
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
        RaycastHit enemy;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (player.Raycast(ray, out enemy, 500))
        {
            enemy.collider.GetComponent<Enemy>().TakeDamage(damage);
            Debug.Log(enemy.collider.name);
        }
    }
}
