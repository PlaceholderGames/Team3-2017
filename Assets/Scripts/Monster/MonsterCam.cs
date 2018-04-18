using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MonsterCam : MonoBehaviour {

    [SerializeField] //SerializeField means that you can see the variable in the Inspector within Unity, without it being public.
    Camera cam;

    [SerializeField]
    GameObject player;

    [SerializeField]
    NavMeshAgent nav;

    public float viewDistance = 10f;

	// Use this for initialization
	void Start () {
		if(cam == null)
            cam = this.GetComponentInChildren<Camera>(); //finds camera if you haven't set it yourself

        if (player == null)
            player = GameObject.Find("First Person Controller (1)"); //change to the players name if ever changed.

        if (nav == null)
            nav = this.GetComponent<NavMeshAgent>();
	}
	
	// Update is called once per frame
	void Update () {
		if(I_Can_See(player))//checks if the camera is rendering the player
        {
            RaycastHit hit;
            if(Physics.Raycast(transform.position, player.transform.position, out hit, viewDistance))
            {
                if(hit.transform.gameObject == player)
                {
                    //move towards the player
                    nav.SetDestination(player.transform.position);
                }
                else
                {

                }
            }
        }
	}

    private bool I_Can_See(GameObject Object)
    {
        Plane[] planes = GeometryUtility.CalculateFrustumPlanes(cam);
        if (GeometryUtility.TestPlanesAABB(planes, Object.GetComponent<Collider>().bounds))
            return true;
        else
            return false;
    }
}
