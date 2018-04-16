using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flashlight : MonoBehaviour {

    public int DamagePerShot = 1;
    public float timeBetweenBullets = 0.15f;
    public float range = 10f;
    public GameObject Spotlight;
    float Timer;
    Ray ShootRay;
    RaycastHit ShootHit;

    void Update()
    {

        Timer += Time.deltaTime;

        if (Input.GetKeyDown(KeyCode.Mouse1) && Timer >= timeBetweenBullets)
        {
            if (Spotlight.GetComponent<Light>().enabled == false)
            {
                Spotlight.GetComponent<Light>().enabled = true;

                Timer = 0f;

                ShootRay.origin = transform.position;
                ShootRay.direction = transform.forward;

                if (Physics.Raycast(ShootRay, out ShootHit, range))
                {
                    MonsterHealth monsterHealth = ShootHit.collider.GetComponent<MonsterHealth>();

                    if (monsterHealth != null)
                    {
                        monsterHealth.TakeDamage(DamagePerShot, ShootHit.point);
                    }
                }
            }
            else
            {
                Spotlight.GetComponent<Light>().enabled = false;
            }
        }
    }
}
