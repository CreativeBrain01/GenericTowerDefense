using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitGateway : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            Destroy(other.gameObject);
            GameController.lives--;
        }
    }
}