using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ballRetrner : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Balls")
        {
            other.gameObject.GetComponent<BallBehaviour>().returnBall();
        }
    }
}
