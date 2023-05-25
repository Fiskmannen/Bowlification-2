using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PinBehaviour : MonoBehaviour
{
    public bool standing;
    public Vector3 originPosition;
    // Start is called before the first frame update
    void Start()
    {
        originPosition = transform.position;
        //STANDING SKA VARA FALSE, RÄKNARE SÄTTER TILL TRUE
        GetComponent<Animator>().enabled = false;
        GetComponent<Rigidbody>().isKinematic = false;
        standing = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void resetStandingPins()
    {
        if (standing == true)
        {
            GetComponent<Animator>().enabled = true;
            GetComponent<Rigidbody>().isKinematic = true;
            GetComponent<Animator>().SetTrigger("Lift Pin");
            Debug.Log("Resetting pins");
        }
    }
}
