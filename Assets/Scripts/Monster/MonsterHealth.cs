using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterHealth : MonoBehaviour {

    public int TotalHealth = 1;
    public int CurrentHelth;

    CapsuleCollider capsuleCollider;
    bool IsHit;

	void Awake ()
    {
        CurrentHelth = TotalHealth;            
	}

    void Update()
    {
        if(IsHit)
        {
            GetComponent<MonsterMovement>().MonsterToStart();
            Invoke("" , 20f);
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
            IsHit = true;
        }
    }

    void Hit()
    {
        IsHit = true;

        capsuleCollider.isTrigger = true;
    }
}
