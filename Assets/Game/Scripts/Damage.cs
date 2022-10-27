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
    private PlayerMovement damage;
    // Start is called before the first frame update
    void Start()
    {
        damage = GetComponent<PlayerMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        switch(enemyType)
        {
            case EnemyDamage.EASY:
                //damage.TakeDamage(5);
                break;
            case EnemyDamage.MEDIUM:
                damage.TakeDamage(10);
                break;
            case EnemyDamage.HARD:
                damage.TakeDamage(20);
                break;
            case EnemyDamage.EXPERT:
                damage.TakeDamage(30);
                break;
            case EnemyDamage.EXTREME:
                damage.TakeDamage(50);
                break;

        }
    }
}
