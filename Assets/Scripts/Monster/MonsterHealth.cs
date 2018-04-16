using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterHealth : MonoBehaviour {

    public int TotalHealth = 1;
    public int CurrentHelth;
    public GameObject MonsterBody;
    MonsterMovement monsterMovement;
    CapsuleCollider capsuleCollider;

    public Transform Monster;
    public Transform StartingPos;
    public float speed;
    bool Died = false;
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

            float step = speed * Time.deltaTime;
            transform.position = Vector3.MoveTowards(Monster.position, StartingPos.position, step);
            MonsterBody.SetActive(false);
            Invoke("MoveOn" , 20f);           
            CurrentHelth = TotalHealth;
            IsHit = false;
        }
    }

    public void TakeDamage(int amount, Vector3 hitPoint)
    {
        if (IsHit)
        {
            return;
        }

        CurrentHelth -= amount;            

        if(CurrentHelth >= 0)

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
        MonsterBody.SetActive(true);
    }
}
