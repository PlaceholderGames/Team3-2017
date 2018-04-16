using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour {

	public int TotalHeath = 3;
    public int CurrntHeath;

    bool IsDead;
    bool Damaged;

	void Awake ()
    {
        CurrntHeath = TotalHeath;
	}
	
	
	void Update () {
		
        if (Damaged)
        {
           
        }
	}

    public void TakeDamage (int amount)
    {

        Damaged = true;

        CurrntHeath -= amount;

        if(CurrntHeath <= 0 && !IsDead)
        {
            Death();
        }
    }

    void Death()
    {
        IsDead = true;

        SceneManager.LoadScene("Credits");

    }
}
