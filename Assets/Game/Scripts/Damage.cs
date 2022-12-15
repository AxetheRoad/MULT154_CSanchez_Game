using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damage : MonoBehaviour
{
    public enum EnemyDamage
    {
        EASY,
        MEDIUM,
        HARD,
        EXPERT,
        EXTREME
    }

    public EnemyDamage enemyType;
    private PlayerMovement hit;
 
    public int damage = 0;
    // Start is called before the first frame update
    void Start()
    {
        hit = GetComponent<PlayerMovement>();
      
    }

    // Update is called once per frame
    void Update()
    {
        switch(enemyType)
        {
            case EnemyDamage.EASY:
                hit.TakeDamage(damage = 10);
                break;
            case EnemyDamage.MEDIUM:
                hit.TakeDamage(damage = 20);
                break;
            case EnemyDamage.HARD:
                hit.TakeDamage(damage = 30);
                break;
            case EnemyDamage.EXPERT:
                hit.TakeDamage(damage = 50);
                break;
            case EnemyDamage.EXTREME:
                hit.TakeDamage(damage = 100);
                break;

        }
    }
    public void OnTriggerEnter(Collider other)
    {
        other.gameObject.GetComponent<PlayerMovement>().TakeDamage(damage);
        return;
    }
}
