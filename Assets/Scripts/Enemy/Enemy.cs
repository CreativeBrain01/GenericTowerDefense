using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class Enemy : MonoBehaviour
{
    public float speed = 20.0f;
    public float health = 100.0f;

    GameObject goalObj;
    NavMeshAgent movement;
    void Start()
    {
        GameObject[] gameObjs = FindObjectsOfType<GameObject>();
        foreach(GameObject go in gameObjs)
        {
            if (go.tag == "Exit")
            {
                goalObj = go;
            }
        }
        movement.SetDestination(goalObj.transform.position);
        movement.speed = speed * 200.0f; //Speed gets multiplied as Terrain objects are 1kx1k areas(forced)
    }

    private void OnCollisionEnter(Collision collision)
    {
        GameObject colGO = collision.gameObject;

        if (colGO.tag == "Exit")
        {
            //Run code related to life loss here
            Destroy(this);
        } else if (colGO.tag == "Projectile")
        {
            //Add code related to checking how much damage they would ACTUALLY take here
            health--;
            if (health <= 0)
            {
                Destroy(this);
            }
        }
    }
}
