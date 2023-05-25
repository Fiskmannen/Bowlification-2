using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class gameManagementScript : MonoBehaviour
{
    public int round;
    public int turn;
    public int previewsLeft;
    public int playerAmount;
    public string player1Name;
    public string player2Name;
    public string player3Name;
    public string player4Name;
    public GameObject highlightBlock;
    public int currentBallID;
    public GameObject redBall;
    public GameObject orangeBall;
    public GameObject blueBall;
    public GameObject pinkBall;
    public GameObject nextBallButtonObj;
    public GameObject mainCamera;
    public GameObject UI;
    public GameObject throwAnchor;
    public GameObject returnTrigger;
    public GameObject nameBanner;
    public GameObject shotMenu;
    public int rand11;
    public int rand12;
    public int rand21;
    public int rand22;
    public int rand31;
    public int rand32;
    public Text rand11text;
    public Text rand12text;
    public Text rand21text;
    public Text rand22text;
    public Text rand31text;
    public Text rand32text;
    public int p1SelectedBall;
    public int p2SelectedBall;
    public int p3SelectedBall;
    public int p4SelectedBall;
    public GameObject monitorUI;
    public GameObject followCamera;
    void Start()
    {
        currentBallID = 0;
        playerAmount = 2;
        round = 0;
        turn = 0;
    }
    private void Update()
    {
        p1SelectedBall = UI.GetComponent<UIBehaviour>().player1Ball;
        p2SelectedBall = UI.GetComponent<UIBehaviour>().player2Ball;
        p3SelectedBall = UI.GetComponent<UIBehaviour>().player3Ball;
        p4SelectedBall = UI.GetComponent<UIBehaviour>().player4Ball;
    }
    public void nextBallButton()
    {
        StartCoroutine(removeWall());
        currentBallID++;
        if (currentBallID == 4)
        {
            currentBallID = 0;
        }
        if (currentBallID == 0) 
        {
            redBall.GetComponent<BallBehaviour>().highlightBall();
            
            //Ta fram r�d, ta bort rosa
        }
        if (currentBallID == 1) 
        { 
            orangeBall.GetComponent<BallBehaviour>().highlightBall();
           
            //Ta fram orange, ta bort r�d
        }
        if (currentBallID == 2) 
        { 
            blueBall.GetComponent<BallBehaviour>().highlightBall();
            //Ta fram bl�, ta bort orange
        }
        if (currentBallID == 3) 
        { 
            pinkBall.GetComponent<BallBehaviour>().highlightBall();
            //Ta fram rosa, ta bort bl�
        }
        StartCoroutine(waitForRoll());
    }
    IEnumerator waitForRoll() 
    { 
        nextBallButtonObj.GetComponent<Button>().interactable = false;

        yield return new WaitForSeconds(2);

        nextBallButtonObj.GetComponent<Button>().interactable = true;
    }
    IEnumerator removeWall() 
    { 
        highlightBlock.GetComponent<BoxCollider>().enabled = false;

        yield return new WaitForSeconds(2);

        highlightBlock.GetComponent<BoxCollider>().enabled = true;
    }
    public bool spareShot;
    public int fallenPins;

    //######## Spelets G�ng ########
    public void initializeNextTurn()
    {
        mainCamera.SetActive(true);
        followCamera.SetActive(false);
        previewsLeft = 1;
        mainCamera.GetComponent<Animator>().SetTrigger("Standard Shot");
        if (fallenPins == 10) //Strike!
        {
            turn++;
        }
        else
        {
            if (spareShot == true) //Spare �ver
            {
                spareShot = false;
                turn++;
            }
            else //N�sta blir spare
            { 
                spareShot = true;
            }
            //Maksin som plockar upp n�r push bar sveper k�nner av vilka som st�r upp, fallenpins �r fr�n b�rjan 10, f�r varje k�gla som kolliderar med plocka upp saken subtrakeras ett fr�n fallenpins
        }

        turn++; //ska tas bort n�r ovanst�ende fungerar
        StartCoroutine(kastMenyInTimer());
        rand11 = Random.Range(5, 10); rand11text.text = rand11.ToString();
        rand12 = Random.Range(5, 10); rand12text.text = rand12.ToString();
        rand21 = Random.Range(1, 10); rand21text.text = rand21.ToString();
        rand22 = Random.Range(1, 10); rand22text.text = rand22.ToString();
        rand31 = Random.Range(3, 5); rand31text.text = rand31.ToString();
        rand32 = Random.Range(3, 10); rand32text.text = rand32.ToString();
        monitorUI.SetActive(true);

        //##### Vem kastar? #####
        if (turn == 1)//Spelare 1 kastar 
        {
            if (p1SelectedBall == 0) //Flytta r�tt klot till bana, s�tt till aktivt
            {
                redBall.GetComponent<Transform>().position = throwAnchor.transform.position;
                redBall.GetComponent<BallBehaviour>().Active = true;
            }
            if (p1SelectedBall == 1) //Flytta orange klot till bana, s�tt till aktivt
            {
                orangeBall.GetComponent<Transform>().position = throwAnchor.transform.position;
                orangeBall.GetComponent<BallBehaviour>().Active = true;
            }
            if (p1SelectedBall == 2) //Flytta bl�tt klot till bana, s�tt till aktivt
            {
                blueBall.GetComponent<Transform>().position = throwAnchor.transform.position;
                blueBall.GetComponent<BallBehaviour>().Active = true;
            }
            if (p1SelectedBall == 3) //Flytta rosa klot till bana, s�tt till aktivt
            {
                pinkBall.GetComponent<Transform>().position = throwAnchor.transform.position;
                pinkBall.GetComponent<BallBehaviour>().Active = true;
            }
            nameBanner.GetComponentInChildren<Text>().text = player1Name + "'S TURN!";
        }
        if (turn == 2)//Spelare 2 kastar 
        {
            if (p2SelectedBall == 0) //Flytta r�tt klot till bana, s�tt till aktivt
            {
                redBall.GetComponent<Transform>().position = throwAnchor.transform.position;
                redBall.GetComponent<BallBehaviour>().Active = true;
            }
            if (p2SelectedBall == 1) //Flytta orange klot till bana, s�tt till aktivt
            {
                orangeBall.GetComponent<Transform>().position = throwAnchor.transform.position;
                orangeBall.GetComponent<BallBehaviour>().Active = true;
            }
            if (p2SelectedBall == 2) //Flytta bl�tt klot till bana, s�tt till aktivt
            {
                blueBall.GetComponent<Transform>().position = throwAnchor.transform.position;
                blueBall.GetComponent<BallBehaviour>().Active = true;
            }
            if (p2SelectedBall == 3) //Flytta rosa klot till bana, s�tt till aktivt
            {
                pinkBall.GetComponent<Transform>().position = throwAnchor.transform.position;
                pinkBall.GetComponent<BallBehaviour>().Active = true;
            }
            nameBanner.GetComponentInChildren<Text>().text = player2Name + "'S TURN!";
        }
        if (turn == 3)//Spelare 3 kastar 
        {
            if (p3SelectedBall == 0) //Flytta r�tt klot till bana, s�tt till aktivt
            {
                redBall.GetComponent<Transform>().position = throwAnchor.transform.position;
                redBall.GetComponent<BallBehaviour>().Active = true;
            }
            if (p3SelectedBall == 1) //Flytta orange klot till bana, s�tt till aktivt
            {
                orangeBall.GetComponent<Transform>().position = throwAnchor.transform.position;
                orangeBall.GetComponent<BallBehaviour>().Active = true;
            }
            if (p3SelectedBall == 2) //Flytta bl�tt klot till bana, s�tt till aktivt
            {
                blueBall.GetComponent<Transform>().position = throwAnchor.transform.position;
                blueBall.GetComponent<BallBehaviour>().Active = true;
            }
            if (p3SelectedBall == 3) //Flytta rosa klot till bana, s�tt till aktivt
            {
                pinkBall.GetComponent<Transform>().position = throwAnchor.transform.position;
                pinkBall.GetComponent<BallBehaviour>().Active = true;
            }
            nameBanner.GetComponentInChildren<Text>().text = player3Name + "'S TURN!";
        }
        if (turn == 4)//Spelare 4 kastar 
        {
            if (p4SelectedBall == 0) //Flytta r�tt klot till bana, s�tt till aktivt
            {
                redBall.GetComponent<Transform>().position = throwAnchor.transform.position;
                redBall.GetComponent<BallBehaviour>().Active = true;
            }
            if (p4SelectedBall == 1) //Flytta orange klot till bana, s�tt till aktivt
            {
                orangeBall.GetComponent<Transform>().position = throwAnchor.transform.position;
                orangeBall.GetComponent<BallBehaviour>().Active = true;
            }
            if (p4SelectedBall == 2) //Flytta bl�tt klot till bana, s�tt till aktivt
            {
                blueBall.GetComponent<Transform>().position = throwAnchor.transform.position;
                blueBall.GetComponent<BallBehaviour>().Active = true;
            }
            if (p4SelectedBall == 3) //Flytta rosa klot till bana, s�tt till aktivt
            {
                pinkBall.GetComponent<Transform>().position = throwAnchor.transform.position;
                pinkBall.GetComponent<BallBehaviour>().Active = true;
            }
            nameBanner.GetComponentInChildren<Text>().text = player4Name + "'S TURN!";
        }
        if (turn == playerAmount + 1) //Rundan �ver
        {
            if (round == 4)
            {
                //Avsluta
            }
            else
            {
                //Ny runda
                round++;
                turn = 0;
                initializeNextTurn();
            }
        }
        //Deactivate physics of active ball
        if (redBall.GetComponent<BallBehaviour>().Active == true) 
        { 
            redBall.GetComponent<Rigidbody>().isKinematic = true;
        }
        if (orangeBall.GetComponent<BallBehaviour>().Active == true)
        {
            orangeBall.GetComponent<Rigidbody>().isKinematic = true;
        }
        if (blueBall.GetComponent<BallBehaviour>().Active == true)
        {
            blueBall.GetComponent<Rigidbody>().isKinematic = true;
        }
        if (pinkBall.GetComponent<BallBehaviour>().Active == true)
        {
            pinkBall.GetComponent<Rigidbody>().isKinematic = true;
        }
    }
    void kastmenyIn()
    {
        shotMenu.GetComponent<Animator>().SetTrigger("Shot In");
        UI.GetComponent<UIBehaviour>().updateShotMenu();
    }
    void kastmenyOut()
    {
        shotMenu.GetComponent<Animator>().SetTrigger("Shot Out");
        UI.GetComponent<UIBehaviour>().updateShotMenu();
    }
    public void returnAllActivatedBalls()
    {
        StartCoroutine(returnAllActiveBalls());
    }
    IEnumerator returnAllActiveBalls()
    {
        yield return new WaitForSeconds(1);
        if (redBall.GetComponent<BallBehaviour>().Active == false)
        {
            redBall.GetComponent<BallBehaviour>().filterSelected();
        }
        yield return new WaitForSeconds(2);
        if (orangeBall.GetComponent<BallBehaviour>().Active == false)
        {
            orangeBall.GetComponent<BallBehaviour>().filterSelected();
        }
        yield return new WaitForSeconds(2);
        if (blueBall.GetComponent<BallBehaviour>().Active == false)
        {
            blueBall.GetComponent<BallBehaviour>().filterSelected();
        }
        yield return new WaitForSeconds(2);
        if (pinkBall.GetComponent<BallBehaviour>().Active == false)
        {
            pinkBall.GetComponent<BallBehaviour>().filterSelected();
        }
        highlightBlock.GetComponent<BoxCollider>().enabled = false; 
        returnTrigger.gameObject.GetComponent<ReturnBallHL>().ongoingHighlight = false;
    }
    public void updateShotAnchor()
    {
        //Aim
        Vector3 desiredPosition;
        desiredPosition.x = 1.36f + (UI.GetComponent<UIBehaviour>().aimSum) / 70;
        desiredPosition.y = 1.996f;
        desiredPosition.z = -18.13f;
        throwAnchor.transform.position = desiredPosition;
        //Stretch shot anchor and arrow according to strength

    }
    IEnumerator kastMenyInTimer()
    {
        yield return new WaitForSeconds(5);

        nameBanner.GetComponent<Animator>().SetTrigger("Show Name");

        yield return new WaitForSeconds(3);

        kastmenyIn();
    }
    public GameObject pin0;
    public GameObject pin1;
    public GameObject pin2;
    public GameObject pin3;
    public GameObject pin4;
    public GameObject pin5;
    public GameObject pin6;
    public GameObject pin7;
    public GameObject pin8;
    public GameObject pin9;
    public void afterShotTimer()
    {
        StartCoroutine(afterShot());
    }
    IEnumerator afterShot()
    {
        yield return new WaitForSeconds(8);

        //Pincounter moves down

        //Lift pins
        //pin0.GetComponent<PinBehaviour>().resetStandingPins();
        

        yield return new WaitForSeconds(3);

        //Present fallen pins
        //Pushbar
        //Fade to black

        yield return new WaitForSeconds(1);

        //Fade out
        //Normal camera
    }
}
