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
    private SphereCollider col;
    public bool TimeToStop = false;

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

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == player)
        {
            Vector3 direction = player.transform.position - transform.position;
            {
                RaycastHit hit;

                if (Physics.Raycast(transform.position + transform.up, direction.normalized, out hit, col.radius))
                {
                    if (hit.collider.gameObject == player)
                    {
                        Debug.Log("player in sight");
                        //Stuff happens that makes the enemy chase the player
                    }
                }
            }
        }
    }

    void Update()
    {
          
        if (!TimeToStop)
        {
           if (!agent.pathPending && agent.remainingDistance < 0.5f)
            {
                GotoNextPoint();
            }   
        }     
    }

    public void MonsterToStart()
    {
        float step = speed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(Monster.position, StartingPos.position, step);
        TimeToStop = true;
        MonsterBody.SetActive(false);
    }
}
