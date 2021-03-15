using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerPlacer : MonoBehaviour
{
    public static GameObject tower;
    public GameObject rangeDisplay;

    void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out RaycastHit hitInfo))
        {
            GameObject collider = hitInfo.collider.gameObject;
            if (Input.GetMouseButtonDown(0) && GameController.score >= tower.GetComponent<Tower>().towerCost && collider.CompareTag("Tower"))
            {
                GameObject.Instantiate<GameObject>(tower.gameObject, hitInfo.point, Quaternion.identity);
                GameController.score -= tower.GetComponent<Tower>().towerCost;
            }
            if (Input.GetKey(KeyCode.LeftShift) && collider.GetComponent<Tower>())
            {
                Tower selTower = collider.GetComponent<Tower>();
                Vector3 towerPos = collider.transform.position;
                Vector3 newPos = new Vector3(towerPos.x, towerPos.y + tower.transform.localScale.y, +towerPos.z);
                rangeDisplay.transform.position = newPos;
                float newScale = (float)(selTower.range / 2.5);
                rangeDisplay.transform.localScale = new Vector3(newScale, newScale);
            } else
            {
                rangeDisplay.transform.localScale = new Vector3(0, 0, 0);
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
