using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Projectile : MonoBehaviour
{
    public float speed = 10.0f;
    public float damage = 1.0f;

    public GameObject target { get; set; }

    Rigidbody rb;
    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.useGravity = false;
    }

    private void Update()
    {
        if (target == null)
        {
            Enemy[] gObjs = FindObjectsOfType<Enemy>();
            if (gObjs.Length == 0)
            {
                Destroy(this.gameObject);
                return;
            }

            float shortestDistance = float.MaxValue;
            foreach (Enemy e in gObjs)
            {
                float dist = Vector3.Distance(e.transform.position, transform.position);
                if (dist < shortestDistance)
                {
                    shortestDistance = dist;
                    target = e.gameObject;
                }
            }
        }

        Vector3 direction = Vector3.zero;

        direction += (target.transform.position - transform.position).normalized;

        rb.AddForce(direction * (speed * 100) * Time.deltaTime);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            CollisionEvent();
        }
    }

    public virtual void CollisionEvent()
    {
        Destroy(this.gameObject);
    }
}
