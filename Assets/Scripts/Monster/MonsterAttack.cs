using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterAttack : MonoBehaviour {

    public float timeBetweenAttacks = 0.5f;
    public int attackDamage = 1;

    GameObject Player;
    PlayerHealth PlayerHealth;

    bool PlayerInRange;
    float Timer;

    void Awake()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
        PlayerHealth = Player.GetComponent<PlayerHealth>();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == Player)
        {
            PlayerInRange = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject == Player)
        {
            PlayerInRange = false;
        }
    }

    void Update()
    {
        Timer += Time.deltaTime;

        if (Timer >= timeBetweenAttacks && PlayerInRange)
        {
            Attack();
        }
    }

    void Attack()
    {
        Timer = 0f;

        if(PlayerHealth.CurrntHeath > 0)
        {
            PlayerHealth.TakeDamage(attackDamage);
        }
    }

}
