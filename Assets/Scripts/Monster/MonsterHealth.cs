using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterHealth : MonoBehaviour {

    public int TotalHealth;
    public int CurrentHelth;

    bool IsHit;

	void Awake ()
    {
        CurrentHelth = TotalHealth;            
	}

    void Update()
    {
        if(IsHit)
        {
            transform.Translate(GetComponent<MonsterMovement>().MonsterToStart());
        }
    }

    void TakeDamage(int amount, Vector3 hitPoint)
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
}
