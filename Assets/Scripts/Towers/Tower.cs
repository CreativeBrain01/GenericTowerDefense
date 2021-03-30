using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(MeshCollider))]
public class Tower : MonoBehaviour
{
    public float fireRate;
    public float range;
    public string targetTag;
    public int towerCost;
    public int damage;

    public GameObject projectile;

    public string Description = "Please Add A Description";
    public string SplashText = "Please Add Some Funny Splash Text";

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

    protected void Update()
    {
        Debug.DrawLine(transform.position, (transform.forward * range) + transform.position);
        List<GameObject> objectsInRange = FindInRange();

        if (objectsInRange.Count > 0)
        {
            fireTimer -= Time.deltaTime;
            if (fireTimer <= 0)
            {
                fireTimer = fireRate;
                Fire(objectsInRange);
            }
        }
        else
        {
            fireTimer = 0;
        }
    }

    protected List<GameObject> FindInRange()
    {
        GameObject[] gameObjects = GameObject.FindGameObjectsWithTag(targetTag);
        List<GameObject> objectsInRange = new List<GameObject>();
        foreach (GameObject go in gameObjects)
        {
            if (Vector3.Distance(go.transform.position, transform.position) < range)
            {
                objectsInRange.Add(go);
            }
        }

        return objectsInRange;
    }

    protected virtual void Fire(List<GameObject> inRange)
    {
        transform.LookAt(inRange[0].transform);
        GameObject target = inRange[0];

        Vector3 spawnPos = new Vector3(transform.position.x, transform.position.y + transform.lossyScale.y, transform.position.z);
        Projectile newProj = GameObject.Instantiate<GameObject>(projectile, spawnPos, Quaternion.identity).GetComponent<Projectile>();
        newProj.target = target;
        newProj.damage = damage;
    }
}
