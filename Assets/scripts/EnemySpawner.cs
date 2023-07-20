using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public static EnemySpawner spawner;
    public GameObject spawn;
    private Collider player;
    public int amount;
    private int maxAmount = 10;
    private int extra;
    // Start is called before the first frame update
    void Awake()
    {
        if (spawner == null) spawner = this;
        else if (spawner != this) Destroy(gameObject);
    }
    void Start(){
        player = Player.player.GetComponent<Collider>();
        StartCoroutine(Spawn());
    }
    IEnumerator Spawn() {
        for ( ; ; ) {
            yield return new WaitForSeconds(5);
            for ( ; amount < maxAmount; amount++) {
                Enemy enemy = Instantiate(spawn,
                              player.transform.position + new Vector3(Random.Range(-1f, 1f), Random.Range(-1f, 1f), Random.Range(-1f, 1f)).normalized * 20,
                              Quaternion.identity).GetComponent<Enemy>();
                enemy.life = 3 + extra;
                enemy.maxSpeed = 1 + extra / 10;
                enemy.damage = 10 + extra;
                yield return new WaitForSeconds(.1f);
            }
        }
    }
    IEnumerator Increase() {
        yield return new WaitForSeconds(35);
        for ( ; ; ) {
            yield return new WaitForSeconds(30);
            extra++;
            maxAmount++;
        }
    }
}
