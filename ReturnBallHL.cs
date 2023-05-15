using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReturnBallHL : MonoBehaviour
{
    public bool ongoingHighlight;
    void Start()
    {
        ongoingHighlight = true;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (ongoingHighlight == true)
        {
            if (other.tag == "Balls")
            {
                if (other.gameObject.GetComponent<BallBehaviour>().Selected == false)
                {
                    other.gameObject.GetComponent<BallBehaviour>().returnBall();
                }
            }
        }
    }
}
