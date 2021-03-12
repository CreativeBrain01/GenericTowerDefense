using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerPlacer : MonoBehaviour
{
    public GameObject tower;
    public LayerMask layerMask;
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && GameController.score >= 100)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if(Physics.Raycast(ray, out RaycastHit hitInfo))
            {
                if (hitInfo.collider.gameObject.CompareTag("Tower"))
                {
                    GameObject.Instantiate<GameObject>(tower, hitInfo.point, Quaternion.identity);
                    GameController.score -= 100;
                }
            }
        }
    }
}
