using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class followCamera : MonoBehaviour
{
    public GameObject redBall;
    public GameObject orangeBall;
    public GameObject blueBall;
    public GameObject pinkBall;
    public Vector3 offset;

    void Update()
    {
        if (redBall.GetComponent<BallBehaviour>().Active == true)
        {
            Vector3 desiredPosition = redBall.transform.position + offset;
            Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, 0.1f);
            transform.position = smoothedPosition;
        }
        if (orangeBall.GetComponent<BallBehaviour>().Active == true)
        {
            Vector3 desiredPosition = orangeBall.transform.position + offset;
            Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, 0.1f);
            transform.position = smoothedPosition;
        }
        if (blueBall.GetComponent<BallBehaviour>().Active == true)
        {
            Vector3 desiredPosition = blueBall.transform.position + offset;
            Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, 0.1f);
            transform.position = smoothedPosition;
        }
        if (pinkBall.GetComponent<BallBehaviour>().Active == true)
        {
            Vector3 desiredPosition = pinkBall.transform.position + offset;
            Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, 0.1f);
            transform.position = smoothedPosition;
        }
    }
}