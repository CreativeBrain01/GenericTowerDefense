using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathWaypoint : MonoBehaviour
{
    public GameObject nextWayPoint;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            Enemy enemy = collision.gameObject.GetComponent<Enemy>();
            enemy.target = nextWayPoint;
            enemy.UpdateDestination();
        }
    }
}
