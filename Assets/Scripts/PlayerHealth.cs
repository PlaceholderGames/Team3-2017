using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour {

	public int TotalHeath = 30;
    public int CurrntHeath;

    bool IsDead;
    bool Damaged;
    public Text Health;

	void Awake ()
    {
        CurrntHeath = TotalHeath;
	}
	
	
	void Update () {
		
        if (Damaged)
        {
            Health.text = CurrntHeath.ToString();
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
