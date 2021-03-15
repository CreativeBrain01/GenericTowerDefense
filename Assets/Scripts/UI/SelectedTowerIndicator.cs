using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class SelectedTowerIndicator : MonoBehaviour
{
    public List<Button> towerButtons;
    public Color selectedColor;
    public Color normalColor;

    /*private void Start()
    {
        TowerPlacer.tower = towerButtons[0].GetComponent<TowerButton>().tower;
    }*/

    void Update()
    {
        if (towerButtons.Count != 0)
        {
            foreach (Button button in towerButtons)
            {
                if (button.GetComponent<TowerButton>().tower == TowerPlacer.tower)
                {
                    if (button.image.color != selectedColor) button.image.color = selectedColor;
                } else
                {
                    if (button.image.color != normalColor) button.image.color = normalColor;
                }
            }
        }
    }
}
