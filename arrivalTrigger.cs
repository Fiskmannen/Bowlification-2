using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class arrivalTrigger : MonoBehaviour
{
    public GameObject rollbackBlock;
    private void Start()
    {
        rollbackBlock.GetComponent<BoxCollider>().enabled = false;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Balls")
        {
            rollbackBlock.GetComponent<BoxCollider>().enabled = true;
            other.GetComponent<BallBehaviour>().allowCurve = false;
        }
    }
}
