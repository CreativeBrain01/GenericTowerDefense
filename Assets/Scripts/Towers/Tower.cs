using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Tower : MonoBehaviour
{
    public float fireRate;
    public float range;
    public string targetTag;
    public int towerCost;

    public GameObject projectile;

    float fireTimer = 0;
    private Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.constraints = RigidbodyConstraints.FreezePosition;
        rb.constraints = RigidbodyConstraints.FreezeRotationX;
        rb.constraints = RigidbodyConstraints.FreezeRotationZ;
        rb.useGravity = false;
        rb.isKinematic = true;
    }

    private void Update()
    {
        Debug.DrawLine(transform.position, (transform.forward * range) + transform.position);
        GameObject[] gameObjects = GameObject.FindGameObjectsWithTag(targetTag);
        List<GameObject> objectsInRange = new List<GameObject>();
        foreach(GameObject go in gameObjects)
        {
            if (Vector3.Distance(go.transform.position, transform.position) < range)
            {
                objectsInRange.Add(go);
            }
        }

        if(objectsInRange.Count > 0)
        {
            transform.LookAt(objectsInRange[0].transform);

            fireTimer -= Time.deltaTime;
            if(fireTimer <= 0)
            {
                fireTimer = fireRate;
                Fire(objectsInRange.ToArray()[0]);
            }
        }
        else
        {
            fireTimer = 0;
        }
    }

    private void Fire(GameObject target)
    {
        Vector3 spawnPos = new Vector3(transform.position.x, transform.position.y + transform.lossyScale.y, transform.position.z);
        Projectile newProj = GameObject.Instantiate<GameObject>(projectile, spawnPos, Quaternion.identity).GetComponent<Projectile>();
        newProj.target = target;
    }
}
