using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flashlight : MonoBehaviour {

	
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown(KeyCode.Mouse1))
        {
            if(GetComponent<Light>().enabled == false)
            {
                GetComponent<Light>().enabled = true;
            }
            else
            {

                GetComponent<Light>().enabled = false;
            }
        }
	}
}
