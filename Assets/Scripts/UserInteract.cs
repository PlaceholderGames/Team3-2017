using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UserInteract : MonoBehaviour
{

    public float interactDistance = 5f;



    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {

            Ray ray = new Ray(transform.position, transform.forward);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, interactDistance))
            {
                if (GameObject.Find("key") == null)
                {
                    if (hit.collider.CompareTag("Door"))
                    {
                        hit.collider.transform.parent.GetComponent<DoorScript>().ChangeDoorState();

                    }
                }

                if (GameObject.Find("Crowbar") == null)
                {
                    if (Physics.Raycast(ray, out hit, interactDistance))
                    {

                        if (hit.collider.CompareTag("Basement door"))
                        {
                            GameObject[] bDoor = GameObject.FindGameObjectsWithTag("Basement door");

                            foreach (GameObject bd in bDoor)
                            {
                                bd.SetActive(false);
                            }
                        }
                    }

                }

                if (GameObject.Find("axe") == null)
                {
                    if (Physics.Raycast(ray, out hit, interactDistance))
                    {
                        if (hit.collider.CompareTag("Enddoor"))
                        {
                            SceneManager.LoadScene("Credits");
                        }


                    }
                }
            }

        }
    }

}
//This requires the Mesh of the interacted object to be a child of the main object, and tagged correctly to this code. For example, Door tag is on the mesh for the door.
//Main Object requires it's appropriate script on main object. Ex. DoorScript on the main door object.
//

// https://www.youtube.com/watch?v=xcWlXRESo-8