using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pinDetector : MonoBehaviour
{
    public GameObject gameManager;
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Pins")
        {
            other.gameObject.GetComponent<PinBehaviour>().standing = true;
            gameManager.GetComponent<gameManagementScript>().fallenPins--;
        }
    }
}
