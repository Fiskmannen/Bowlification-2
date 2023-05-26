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
        round = 1;
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
            
            //Ta fram röd, ta bort rosa
        }
        if (currentBallID == 1) 
        { 
            orangeBall.GetComponent<BallBehaviour>().highlightBall();
           
            //Ta fram orange, ta bort röd
        }
        if (currentBallID == 2) 
        { 
            blueBall.GetComponent<BallBehaviour>().highlightBall();
            //Ta fram blå, ta bort orange
        }
        if (currentBallID == 3) 
        { 
            pinkBall.GetComponent<BallBehaviour>().highlightBall();
            //Ta fram rosa, ta bort blå
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

    //###################################################### Spelets Gång ############################################################
    public void initializeNextTurn()
    {
        redBall.GetComponent<BallBehaviour>().Active = false;
        orangeBall.GetComponent<BallBehaviour>().Active = false;
        blueBall.GetComponent<BallBehaviour>().Active = false;
        pinkBall.GetComponent<BallBehaviour>().Active = false;
        mainCamera.SetActive(true);
        followCamera.SetActive(false);
        previewsLeft = 1;
        mainCamera.GetComponent<Animator>().SetTrigger("Standard Shot");

        if (turn >= 1)
        {
            if (spareShot == false)
            {
                if (fallenPins == 10) //Strike!
                {
                    turn++;
                    fallenPins = 10;
                    spareShot = false;
                    StartCoroutine(resetAlley());
                }
                else //spare
                {
                    spareShot = true;
                    fallenPins = 10;
                    //Starta om som spare
                }
            }
            else //Kastat spare
            {
                turn++;
                StartCoroutine(resetAlley());
                spareShot = false;
            }
        }
        if (turn == 0)
        {
            turn++;
            fallenPins = 10;
            Debug.Log("Starting new round!");
        }
        
        rand11 = Random.Range(4, 10); rand11text.text = rand11.ToString();
        rand12 = Random.Range(4, 10); rand12text.text = rand12.ToString();
        rand21 = Random.Range(1, 10); rand21text.text = rand21.ToString();
        rand22 = Random.Range(1, 10); rand22text.text = rand22.ToString();
        rand31 = Random.Range(4, 10); rand31text.text = rand31.ToString();
        rand32 = Random.Range(4, 10); rand32text.text = rand32.ToString();
        UI.GetComponent<UIBehaviour>().shotMenuStage = 1;
        UI.GetComponent<UIBehaviour>().aimAddition.isOn = false; UI.GetComponent<UIBehaviour>().aimAddition.interactable = true;
        UI.GetComponent<UIBehaviour>().aimSubtraction.isOn = false; UI.GetComponent<UIBehaviour>().aimSubtraction.interactable = true;
        UI.GetComponent<UIBehaviour>().aimDivision.isOn = false; UI.GetComponent<UIBehaviour>().aimDivision.interactable = true;
        UI.GetComponent<UIBehaviour>().aimMultiplication.isOn = false; UI.GetComponent<UIBehaviour>().aimMultiplication.interactable = true;
        UI.GetComponent<UIBehaviour>().curveAddition.isOn = false; UI.GetComponent<UIBehaviour>().curveAddition.interactable = true;
        UI.GetComponent<UIBehaviour>().curveSubtraction.isOn = false; UI.GetComponent<UIBehaviour>().curveSubtraction.interactable = true;
        UI.GetComponent<UIBehaviour>().curveDivision.isOn = false; UI.GetComponent<UIBehaviour>().curveDivision.interactable = true;
        UI.GetComponent<UIBehaviour>().curveMultiplication.isOn = false; UI.GetComponent<UIBehaviour>().curveMultiplication.interactable = true;
        UI.GetComponent<UIBehaviour>().forceAddition.isOn = false; UI.GetComponent<UIBehaviour>().forceAddition.interactable = true;
        UI.GetComponent<UIBehaviour>().forceSubtraction.isOn = false; UI.GetComponent<UIBehaviour>().forceSubtraction.interactable = true;
        UI.GetComponent<UIBehaviour>().forceDivision.isOn = false; UI.GetComponent<UIBehaviour>().forceDivision.interactable = true;
        UI.GetComponent<UIBehaviour>().forceMultiplication.isOn = false; UI.GetComponent<UIBehaviour>().forceMultiplication.interactable = true;
        Debug.Log("Generating new Numbers");
        Debug.Log(rand11 + " " + rand12 + " " + rand21 + " " + rand22 + " " + rand31 + " " + rand32);
        monitorUI.SetActive(true);

        //##### Vem kastar? #####
        if (turn == 1)//Spelare 1 kastar 
        {
            if (p1SelectedBall == 0) //Flytta rött klot till bana, sätt till aktivt
            {
                redBall.GetComponent<Transform>().position = throwAnchor.transform.position;
                redBall.GetComponent<BallBehaviour>().Active = true;
            }
            if (p1SelectedBall == 1) //Flytta orange klot till bana, sätt till aktivt
            {
                orangeBall.GetComponent<Transform>().position = throwAnchor.transform.position;
                orangeBall.GetComponent<BallBehaviour>().Active = true;
            }
            if (p1SelectedBall == 2) //Flytta blått klot till bana, sätt till aktivt
            {
                blueBall.GetComponent<Transform>().position = throwAnchor.transform.position;
                blueBall.GetComponent<BallBehaviour>().Active = true;
            }
            if (p1SelectedBall == 3) //Flytta rosa klot till bana, sätt till aktivt
            {
                pinkBall.GetComponent<Transform>().position = throwAnchor.transform.position;
                pinkBall.GetComponent<BallBehaviour>().Active = true;
            }
            nameBanner.GetComponentInChildren<Text>().text = player1Name + "'S TURN!";
        }
        if (turn == 2)//Spelare 2 kastar 
        {
            if (p2SelectedBall == 0) //Flytta rött klot till bana, sätt till aktivt
            {
                redBall.GetComponent<Transform>().position = throwAnchor.transform.position;
                redBall.GetComponent<BallBehaviour>().Active = true;
            }
            if (p2SelectedBall == 1) //Flytta orange klot till bana, sätt till aktivt
            {
                orangeBall.GetComponent<Transform>().position = throwAnchor.transform.position;
                orangeBall.GetComponent<BallBehaviour>().Active = true;
            }
            if (p2SelectedBall == 2) //Flytta blått klot till bana, sätt till aktivt
            {
                blueBall.GetComponent<Transform>().position = throwAnchor.transform.position;
                blueBall.GetComponent<BallBehaviour>().Active = true;
            }
            if (p2SelectedBall == 3) //Flytta rosa klot till bana, sätt till aktivt
            {
                pinkBall.GetComponent<Transform>().position = throwAnchor.transform.position;
                pinkBall.GetComponent<BallBehaviour>().Active = true;
            }
            nameBanner.GetComponentInChildren<Text>().text = player2Name + "'S TURN!";
        }
        if (turn == 3)//Spelare 3 kastar 
        {
            if (p3SelectedBall == 0) //Flytta rött klot till bana, sätt till aktivt
            {
                redBall.GetComponent<Transform>().position = throwAnchor.transform.position;
                redBall.GetComponent<BallBehaviour>().Active = true;
            }
            if (p3SelectedBall == 1) //Flytta orange klot till bana, sätt till aktivt
            {
                orangeBall.GetComponent<Transform>().position = throwAnchor.transform.position;
                orangeBall.GetComponent<BallBehaviour>().Active = true;
            }
            if (p3SelectedBall == 2) //Flytta blått klot till bana, sätt till aktivt
            {
                blueBall.GetComponent<Transform>().position = throwAnchor.transform.position;
                blueBall.GetComponent<BallBehaviour>().Active = true;
            }
            if (p3SelectedBall == 3) //Flytta rosa klot till bana, sätt till aktivt
            {
                pinkBall.GetComponent<Transform>().position = throwAnchor.transform.position;
                pinkBall.GetComponent<BallBehaviour>().Active = true;
            }
            nameBanner.GetComponentInChildren<Text>().text = player3Name + "'S TURN!";
        }
        if (turn == 4)//Spelare 4 kastar 
        {
            if (p4SelectedBall == 0) //Flytta rött klot till bana, sätt till aktivt
            {
                redBall.GetComponent<Transform>().position = throwAnchor.transform.position;
                redBall.GetComponent<BallBehaviour>().Active = true;
            }
            if (p4SelectedBall == 1) //Flytta orange klot till bana, sätt till aktivt
            {
                orangeBall.GetComponent<Transform>().position = throwAnchor.transform.position;
                orangeBall.GetComponent<BallBehaviour>().Active = true;
            }
            if (p4SelectedBall == 2) //Flytta blått klot till bana, sätt till aktivt
            {
                blueBall.GetComponent<Transform>().position = throwAnchor.transform.position;
                blueBall.GetComponent<BallBehaviour>().Active = true;
            }
            if (p4SelectedBall == 3) //Flytta rosa klot till bana, sätt till aktivt
            {
                pinkBall.GetComponent<Transform>().position = throwAnchor.transform.position;
                pinkBall.GetComponent<BallBehaviour>().Active = true;
            }
            nameBanner.GetComponentInChildren<Text>().text = player4Name + "'S TURN!";
        }
        if (redBall.GetComponent<BallBehaviour>().Active == true) 
        { 
            redBall.GetComponent<BallBehaviour>().thrown = false;
            redBall.GetComponent<BallBehaviour>().allowCurve = false;
        }
        if (orangeBall.GetComponent<BallBehaviour>().Active == true)
        {
            orangeBall.GetComponent<BallBehaviour>().thrown = false;
            orangeBall.GetComponent<BallBehaviour>().allowCurve = false;
        }
        if (blueBall.GetComponent<BallBehaviour>().Active == true)
        {
            blueBall.GetComponent<BallBehaviour>().thrown = false;
            blueBall.GetComponent<BallBehaviour>().allowCurve = false;
        }
        if (pinkBall.GetComponent<BallBehaviour>().Active == true)
        {
            pinkBall.GetComponent<BallBehaviour>().thrown = false;
            pinkBall.GetComponent<BallBehaviour>().allowCurve = false;
        }
        if (turn == playerAmount + 1) //Rundan över
        {
            redBall.GetComponent<BallBehaviour>().returnBall();
            if(round != 5)
            {
                //Ny runda
                fallenPins = 10;
                round++;
                turn = 0;
                initializeNextTurn();
                
            }
            if (round == 5)
            {
                Debug.Log("Ending Game");
            }
            
        }
        if (round != 5)
        {
            StartCoroutine(kastMenyInTimer()); //??
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
        yield return new WaitForSeconds(1);
        if (orangeBall.GetComponent<BallBehaviour>().Active == false)
        {
            orangeBall.GetComponent<BallBehaviour>().filterSelected();
        }
        yield return new WaitForSeconds(1);
        if (blueBall.GetComponent<BallBehaviour>().Active == false)
        {
            blueBall.GetComponent<BallBehaviour>().filterSelected();
        }
        yield return new WaitForSeconds(1);
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
    public GameObject aimMenu;
    public GameObject curveMenu;
    public GameObject forceMenu;
    IEnumerator kastMenyInTimer()
    {
        yield return new WaitForSeconds(5);

        nameBanner.GetComponent<Animator>().SetTrigger("Show Name");

        yield return new WaitForSeconds(3);

        UI.GetComponent<UIBehaviour>().aimOpen = true;
        UI.GetComponent<UIBehaviour>().curveOpen = false;
        UI.GetComponent<UIBehaviour>().forceOpen = false;
        aimMenu.GetComponent<Animator>().SetTrigger("Aim In");
        curveMenu.GetComponent<Animator>().SetTrigger("Curve Out");
        forceMenu.GetComponent<Animator>().SetTrigger("Force Out");
        UI.GetComponent<UIBehaviour>().updateShotMenu();
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
    public GameObject plate0;
    public GameObject plate1;
    public GameObject plate2;
    public GameObject plate3;
    public GameObject plate4;
    public GameObject plate5;
    public GameObject plate6;
    public GameObject plate7;
    public GameObject plate8;
    public GameObject plate9;
    public GameObject liftPlate;
    public GameObject pushBar;
    public void afterShotTimer()
    {
        StartCoroutine(afterShot());
    }
    IEnumerator afterShot()
    {
        yield return new WaitForSeconds(8);

        pushBar.GetComponent<Animator>().SetTrigger("Push Bar Clear");

        liftPlate.GetComponent<Animator>().SetTrigger("Lift Pins");

        yield return new WaitForSeconds(1);

        if (pin0.GetComponent<PinBehaviour>().standing == false)
        {
            plate0.SetActive(false);
        }
        if (pin1.GetComponent<PinBehaviour>().standing == false)
        {
            plate1.SetActive(false);
        }
        if (pin2.GetComponent<PinBehaviour>().standing == false)
        {
            plate2.SetActive(false);
        }
        if (pin3.GetComponent<PinBehaviour>().standing == false)
        {
            plate3.SetActive(false);
        }
        if (pin4.GetComponent<PinBehaviour>().standing == false)
        {
            plate4.SetActive(false);
        }
        if (pin5.GetComponent<PinBehaviour>().standing == false)
        {
            plate5.SetActive(false);
        }
        if (pin6.GetComponent<PinBehaviour>().standing == false)
        {
            plate6.SetActive(false);
        }
        if (pin7.GetComponent<PinBehaviour>().standing == false)
        {
            plate7.SetActive(false);
        }
        if (pin8.GetComponent<PinBehaviour>().standing == false)
        {
            plate8.SetActive(false);
        }
        if (pin9.GetComponent<PinBehaviour>().standing == false)
        {
            plate9.SetActive(false);
        }

        yield return new WaitForSeconds(4);

        Debug.Log("Score: " + fallenPins.ToString());
        UI.GetComponent<UIBehaviour>().updateScoreboard();

        yield return new WaitForSeconds(3);

        //Fade to black

        yield return new WaitForSeconds(1);

        initializeNextTurn();
        //Fade in
        mainCamera.GetComponent<Animator>().SetTrigger("Standard Shot");

        yield return new WaitForSeconds(2);

        ballReturner.GetComponent<Animator>().SetTrigger("Find Balls");
    }
    public GameObject ballReturner;
    
    IEnumerator resetAlley()
    {
        yield return new WaitForSeconds(3);
        liftPlate.GetComponent<Animator>().SetTrigger("Reload");
        yield return new WaitForSeconds(1);
        pin0.GetComponent<PinBehaviour>().resetToOrigin();
        pin1.GetComponent<PinBehaviour>().resetToOrigin();
        pin2.GetComponent<PinBehaviour>().resetToOrigin();
        pin3.GetComponent<PinBehaviour>().resetToOrigin();
        pin4.GetComponent<PinBehaviour>().resetToOrigin();
        pin5.GetComponent<PinBehaviour>().resetToOrigin();
        pin6.GetComponent<PinBehaviour>().resetToOrigin();
        pin7.GetComponent<PinBehaviour>().resetToOrigin();
        pin8.GetComponent<PinBehaviour>().resetToOrigin();
        pin9.GetComponent<PinBehaviour>().resetToOrigin();
        liftPlate.GetComponent<BoxCollider>().enabled = false;
        
        yield return new WaitForSeconds(2);
        liftPlate.GetComponent<BoxCollider>().enabled = true;

        plate0.SetActive(true);
        plate1.SetActive(true);
        plate2.SetActive(true);
        plate3.SetActive(true);
        plate4.SetActive(true);
        plate5.SetActive(true);
        plate6.SetActive(true);
        plate7.SetActive(true);
        plate8.SetActive(true);
        plate9.SetActive(true);
    }
}
