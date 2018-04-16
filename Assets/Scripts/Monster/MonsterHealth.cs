using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterHealth : MonoBehaviour {

    public int TotalHealth = 1;
    public int CurrentHelth;
    public GameObject MonsterBody;
    MonsterMovement monsterMovement;
    CapsuleCollider capsuleCollider;
    bool IsHit;

	void Awake ()
    {
        CurrentHelth = TotalHealth;
        capsuleCollider = GetComponent<CapsuleCollider>();
	}

    void Update()
    {
        if(IsHit)
        {
            monsterMovement.GetComponent<MonsterMovement>().MonsterToStart();
            Invoke("MoveOn" , 20);
            CurrentHelth = TotalHealth;
        }
    }

    public void TakeDamage(int amount, Vector3 hitPoint)
    {
        if (IsHit)
        {
            return;
        }

        CurrentHelth -= amount;            

        if(CurrentHelth <= 0)
        {
            Hit();
        }
    }

    void Hit()
    {
        IsHit = true;

        capsuleCollider.isTrigger = true;
    }

    void MoveOn()
    {
        MonsterBody.SetActive(false);
    }
}
