using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
    public float fireRate;
    public float range;
    public string targetTag;

    public GameObject projectile;

    float fireTimer = 0;

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
            fireTimer -= Time.deltaTime;
            //objectsInRange.Reverse();
            if(fireTimer <= 0)
            {
                //float longestLiving = float.MaxValue;

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
        Projectile newProj = GameObject.Instantiate<GameObject>(projectile, transform.position, Quaternion.identity).GetComponent<Projectile>();
        newProj.target = target;
    }
}
