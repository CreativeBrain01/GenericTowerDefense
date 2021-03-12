using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class Enemy : MonoBehaviour
{
    public float speed = 20.0f;
    [Range(10.0f, 180.0f)]public float turnRate = 20.0f;
    public float health = 100.0f;
    public GameObject target;

    NavMeshAgent movement;
    void Start()
    {
        movement = GetComponent<NavMeshAgent>();
        movement.speed = speed * 200.0f; //Speed gets multiplied as Terrain objects are 1kx1k areas(forced)
        movement.angularSpeed = turnRate;
        UpdateDestination();
    }

    public void UpdateDestination()
    {
        movement.SetDestination(target.transform.position);
    }

    private void OnCollisionEnter(Collision collision)
    {
        GameObject colGO = collision.gameObject;

        if (colGO.tag == "Exit")
        {
            //Run code related to life loss here
            Destroy(this.gameObject);
        } else if (colGO.tag == "Projectile")
        {
            //Add code related to checking how much damage they would ACTUALLY take here
            Projectile proj = colGO.GetComponent<Projectile>();
            health -= proj.damage;
            if (health <= 0)
            {
                Destroy(this.gameObject);
            }
        }
    }
}
