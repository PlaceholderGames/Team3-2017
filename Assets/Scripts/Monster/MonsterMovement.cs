using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterMovement : MonoBehaviour {

    public GameObject MonsterBody;
    public Transform player;
    public Transform[] points;
    public Transform Monster;
    public Transform StartingPos;
    public float speed;
    private int destPoint = 0;
    private UnityEngine.AI.NavMeshAgent agent;
    private UnityEngine.AI.NavMeshAgent nav;
    private SphereCollider col;
    public bool seePlayer;
    public float sightRange;


    void Start()
    {

        agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
        col = GetComponent<SphereCollider>();
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
   
    void Update()
    {
        seePlayer = false;
        RaycastHit hit;
        Ray MonsterHit = new Ray(transform.position, Vector3.forward);

        if (Physics.Raycast(MonsterHit, out hit, sightRange))
        {

            //Debug.DrawLine(MonsterHit.origin, hit.point);

            if (hit.collider.tag == "Player")
            {
                seePlayer = true;
            }
        }

        if (seePlayer)
        {
            nav.SetDestination(player.position);
            Walk();
        }
        else
        {
            if (!agent.pathPending && agent.remainingDistance < 0.5f)
                GotoNextPoint();
        }
    }

    void Walk()
    {

        player = GameObject.FindGameObjectWithTag("Player").transform;
        nav = GetComponent<UnityEngine.AI.NavMeshAgent>();

    }
}
