using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FootSteps : MonoBehaviour {

    CharacterController cc;

	// Use this for initialization
	void Start () {
        cc = GetComponent<CharacterController>();
	}
	
	// Update is called once per frame
	void Update () {
		if (cc.isGrounded == true &&  Input.GetKeyDown(KeyCode.W))
        {
            GetComponent<AudioSource>().Play();
        }
        if (cc.isGrounded == true && Input.GetKeyDown(KeyCode.A))
        {
            GetComponent<AudioSource>().Play();
        }
        if (cc.isGrounded == true && Input.GetKeyDown(KeyCode.S))
        {
            GetComponent<AudioSource>().Play();
        }
        if (cc.isGrounded == true && Input.GetKeyDown(KeyCode.D))
        {
            GetComponent<AudioSource>().Play();
        }
        if (Input.GetKey(KeyCode.W) == false && Input.GetKey(KeyCode.A) == false && Input.GetKey(KeyCode.S) ==false && Input.GetKey(KeyCode.D) == false)
         {
            GetComponent<AudioSource>().Stop();
        }
       
    }


}
