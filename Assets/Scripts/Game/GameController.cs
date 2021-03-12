using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public Text livesTxt;
    public Text scoreTxt;

    public static int score = 100;
    public static int lives = 100;

    private void Update()
    {
        livesTxt.text = "Lives: " + lives;
        scoreTxt.text = "Score: " + score;
    }
}
