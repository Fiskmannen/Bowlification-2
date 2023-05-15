using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RollbackBehaviour : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Balls")
        {
            other.gameObject.GetComponent<BallBehaviour>().activateRollback();
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Balls")
        {
            other.gameObject.GetComponent<BallBehaviour>().deactivateRollback();
        }
    }
}
