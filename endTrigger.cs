using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class endTrigger : MonoBehaviour
{
    public GameObject UI;
    public GameObject mainCamera;
    public GameObject followCamera;
    public GameObject gameManager;
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Balls")
        {
            if (UI.GetComponent<UIBehaviour>().ongoingShot == true)
            {
                //Move main camera
                followCamera.SetActive(false);
                mainCamera.SetActive(true);
                mainCamera.GetComponent<Animator>().SetTrigger("Pin Camera");
                //start end shot countdown, ready to present amount of pins
                gameManager.GetComponent<gameManagementScript>().afterShotTimer();
            }
        }
        if(other.tag == "Ghost")
        {
            //Preview klot 
        }
    }
}
