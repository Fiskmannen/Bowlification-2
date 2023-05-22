using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallBehaviour : MonoBehaviour
{
    public GameObject gameManager;
    public GameObject UI;
    private bool allowRollback;
    public bool Selected;
    public bool Active;
    public bool thrown;
    public bool allowCurve;
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Rigidbody>().isKinematic = false;
        GetComponent<Animator>().enabled = false;
        allowRollback = true;
        Selected = false;
        thrown = false;
        allowCurve = false;
    }
    public void activateRollback()
    {
        allowRollback = true;
    }
    public void deactivateRollback()
    {
        allowRollback = false;
    }
    public void select()
    {
        Selected = true;
    }
    public void bowl()
    {
        if (Active == true)
        {
            if (thrown == false)
            {
                allowCurve = true;
                thrown = true;
                GetComponent<Rigidbody>().isKinematic = false;
                GetComponent<Animator>().enabled = false;
                gameObject.GetComponent<Rigidbody>().AddForce(0, 0, UI.GetComponent<UIBehaviour>().forceSum / 4, ForceMode.VelocityChange);
            }
        }
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        if (allowRollback == true)
        {
            GetComponent<Rigidbody>().AddForce(0, 0, -2.5f * Time.deltaTime, ForceMode.VelocityChange);
        }
        if (thrown == false) 
        { 
            if (Active == true)
            {
                transform.position = gameManager.GetComponent<gameManagementScript>().throwAnchor.transform.position;
            }
        }
        else
        {
            if (allowCurve == true)
            {
                gameObject.GetComponent<Rigidbody>().AddForce((UI.GetComponent<UIBehaviour>().curveSum * 2) * Time.deltaTime, 0, 0);
            }
        }
    }
    public void returnBall()
    {
        GetComponent<Animator>().enabled = true;
        GetComponent<Rigidbody>().isKinematic = true;
        StartCoroutine(waitForDrop());
        GetComponent<Animator>().SetTrigger("Return");
    }
    IEnumerator waitForDrop()
    {
        yield return new WaitForSeconds(2);
        GetComponent<Animator>().enabled = false;
        GetComponent<Rigidbody>().isKinematic = false;
    }
    public void highlightBall()
    {
        GetComponent<Animator>().enabled = true;
        GetComponent<Rigidbody>().isKinematic = true;
        StartCoroutine(waitForDrop());
        GetComponent<Animator>().SetTrigger("Highlight");
    }
    public void filterSelected()
    {
        if (Selected == true)
        {
            returnBall();
        }
        else
        {
            highlightBall();
        }
    }
}
