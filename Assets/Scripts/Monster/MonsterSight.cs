using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterSight : MonoBehaviour {

    bool SeePlayer = false;
       
    void OnTriggerEnter()
    {
        Debug.Log("True");
        SeePlayer = true;
    }

    void OnTriggerExit()
    {
        Debug.Log("False");
        SeePlayer = false;
    }

    public bool CheckSeePlayer()
    {
        if(SeePlayer)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

}
