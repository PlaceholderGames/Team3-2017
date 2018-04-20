using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterAttack : MonoBehaviour {

    public float timeBetweenAttacks = 1f;
    public int attackDamage = 10;
    public bool Bob;
    GameObject Player;
    PlayerHealth PlayerHealth;
    UserInteract User;
    bool PlayerInRange;
    float Timer;

    void Awake()
    {
        Debug.Log("IM awake");
        Player = GameObject.FindGameObjectWithTag("Player");
        PlayerHealth = Player.GetComponent<PlayerHealth>();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log("In Range");
            PlayerInRange = true;
        }
    }

    //void OnTriggerStay(Collider other)
    //{
    //    if (other.gameObject.CompareTag("Player"))
    //    Debug.Log("It works");
    //}

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log("out of range");
            PlayerInRange = false;
        }
    }

    void Update()
    {
        Timer += Time.deltaTime;
        //if (User.GetComponent<UserInteract>().Hidden)
        //{
            if (Timer >= timeBetweenAttacks && PlayerInRange)
            {
            Debug.Log("Monster Attack");
                Attack();
            }
        //}
        
    }

    void Attack()
    {
        Timer = 0f;
        //Debug.Log("Attacked");
        if(PlayerHealth.CurrntHeath > 0)
        {
            PlayerHealth.TakeDamage(attackDamage);
        }
    }

}
