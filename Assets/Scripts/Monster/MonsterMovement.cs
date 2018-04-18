using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterMovement : MonoBehaviour
{



    public Transform[] points;
    private int destPoint = 0;
    private UnityEngine.AI.NavMeshAgent agent;
    public float sightRange;
    public float patienceDelay = 5f;
    public float viewAngle = 60f;

    public LayerMask playerMask;

    //[SerializeField]
    //Camera cam;

    [SerializeField]
    GameObject player;



    void Start()
    {
        agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
        //if (cam == null)
        //    cam = this.GetComponentInChildren<Camera>(); //finds camera if you haven't set it yourself

        if (player == null)
            player = GameObject.Find("First Person Controller (1)/Graphics"); //change to the players name if ever changed.

        agent.autoBraking = false;

        GotoNextPoint();
    }


    void GotoNextPoint()
    {
        // Returns if no points have been set up
        if (points.Length == 0)
            return;

        // Set the agent to go to the currently selected destination.
        agent.destination = points[destPoint].position;

        // Choose the next point in the array as the destination,
        // cycling to the start if necessary.
        destPoint = (destPoint + 1) % points.Length;
    }

    void ContinueJourney()
    {
        agent.destination = points[destPoint].position;
    }
    void RemoveMarker()
    {
        agent.destination = this.transform.position;
    }


    void Update()
    {
        
        if (I_Can_See(player))//checks if the camera is rendering the player
        {
            RaycastHit hit;
            Physics.Raycast(transform.position, player.transform.position, out hit, sightRange);
            if (hit.transform.tag == "Player")
            {

                //move towards the player
                agent.SetDestination(player.transform.position);
            }
            else
            {

                //RemoveMarker();
                //Invoke("ContinueJourney", patienceDelay);
            }
            //Debug.Log("Player is in range");
            
        }
        else
        {
            if (!agent.pathPending && agent.remainingDistance < 0.5f)
                GotoNextPoint();
        }
    }

    private bool I_Can_See(GameObject Object)
    {
        Collider[] inRange = Physics.OverlapSphere(transform.position, sightRange, playerMask);
        bool playerSee = false;
        for (int i = 0; i < inRange.Length; i++)
        {
            Debug.DebugBreak();
            Transform target = inRange[i].transform;
            Vector3 DiroToTarget = (target.position - transform.position).normalized;

            if (target.position == Object.transform.position)
            {
                if (Vector3.Angle(transform.forward, DiroToTarget) < viewAngle / 2)
                {
                    Debug.Log("They or the same!!");
                    playerSee = true;
                    break;
                }
            }
           
        }
        return playerSee;
        
        //Plane[] planes = GeometryUtility.CalculateFrustumPlanes(cam);
        //if (GeometryUtility.TestPlanesAABB(planes, Object.GetComponent<Collider>().bounds))
        //    return true;
        //else
        //    return false;
    }
}


