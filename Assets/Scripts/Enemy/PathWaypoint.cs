using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathWaypoint : MonoBehaviour
{
    public GameObject nextWayPoint;

    public void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            Enemy enemy = collision.gameObject.GetComponent<Enemy>();
            if (enemy.target.GetComponent<PathWaypoint>() == this)
            {
                enemy.UpdateDestination(nextWayPoint);
            }
        }
    }
}