using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerPlacer : MonoBehaviour
{
    public static GameObject tower;

    void Update()
    {
        if (Input.GetMouseButtonDown(0) && GameController.score >= tower.GetComponent<Tower>().towerCost)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if(Physics.Raycast(ray, out RaycastHit hitInfo))
            {
                if (hitInfo.collider.gameObject.CompareTag("Tower"))
                {
                    GameObject.Instantiate<GameObject>(tower.gameObject, hitInfo.point, Quaternion.identity);
                    GameController.score -= tower.GetComponent<Tower>().towerCost;
                }
            }
        }
    }

    public static void SetTower(GameObject newTower)
    {
        if (newTower.GetComponent<Tower>())
        {
            tower = newTower;
        }
    }
}
