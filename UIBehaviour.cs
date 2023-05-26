using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIBehaviour : MonoBehaviour
{
    public GameObject gameManager;
    public GameObject redBall;
    public GameObject orangeBall;
    public GameObject blueBall;
    public GameObject pinkBall;
    public int initStage;
    public GameObject amountMenu;
    public GameObject nameMenu;
    public GameObject ballMenu;
    public GameObject player1NameObj;
    public GameObject player2NameObj;
    public GameObject player3NameObj;
    public GameObject player4NameObj;
    public GameObject aimMenu;
    public GameObject curveMenu;
    public GameObject forceMenu;
    public GameObject shotMenu;
    public GameObject initializationMenu;
    public Animator amountMenuAnimator;
    public Animator nameMenuAnimator;
    public Animator ballMenuAnimator;
    public GameObject mainCamera;
    public Button playeramountPlus;
    public Button playeramountMinus;
    public Text playerAmountDisplay;
    public Text playerNameDisplay;
    public int player1Ball;
    public int player2Ball;
    public int player3Ball;
    public int player4Ball;
    public int shotMenuStage;
    public Button bowlButtonUI;
    public Button previewButton;
    public GameObject monitorRow1;
    public GameObject monitorRow2;
    public GameObject monitorRow3;
    public GameObject monitorRow4;
    
    // Start is called before the first frame update
    void Start()
    {
        initStage = 1;
        amountMenu.SetActive(true);
        updateUI();
    }

    // Update is called once per frame
    void Update()
    {
        if (selectedAim == true)
        {
            if(selectedCurve == true)
            {
                if(selectedForce == true)
                {
                    //Aktivera preview och bowl
                    bowlButtonUI.interactable = true;
                    previewButton.interactable = true;
                }
                else
                {
                    bowlButtonUI.interactable = false;
                    previewButton.interactable = false;
                }
            }
            else
            {
                bowlButtonUI.interactable = false;
                previewButton.interactable = false;
            }
        }
        else
        {
            bowlButtonUI.interactable = false;
            previewButton.interactable = false;
        }
    }
    public void initNextButton()
    {
        //Antal spelare visas först
        shotMenuStage = 1;
        initStage++;
        if (initStage == 2) //Välj namn
        {
            amountMenuAnimator.SetTrigger("Amount Out");
            nameMenu.SetActive(true);
            if (gameManager.GetComponent<gameManagementScript>().playerAmount == 1)
            {
                player1NameObj.SetActive(true);
                player2NameObj.SetActive(false);
                player3NameObj.SetActive(false);
                player4NameObj.SetActive(false);
                monitorRow1.SetActive(true);
                monitorRow2.SetActive(false);
                monitorRow3.SetActive(false);
                monitorRow4.SetActive(false);
            }
            if (gameManager.GetComponent<gameManagementScript>().playerAmount == 2)
            {
                player1NameObj.SetActive(true);
                player2NameObj.SetActive(true);
                player3NameObj.SetActive(false);
                player4NameObj.SetActive(false);
                monitorRow1.SetActive(true);
                monitorRow2.SetActive(true);
                monitorRow3.SetActive(false);
                monitorRow4.SetActive(false);
            }
            if (gameManager.GetComponent<gameManagementScript>().playerAmount == 3)
            {
                player1NameObj.SetActive(true);
                player2NameObj.SetActive(true);
                player3NameObj.SetActive(true);
                player4NameObj.SetActive(false);
                monitorRow1.SetActive(true);
                monitorRow2.SetActive(true);
                monitorRow3.SetActive(true);
                monitorRow4.SetActive(false);
            }
            if (gameManager.GetComponent<gameManagementScript>().playerAmount == 4)
            {
                player1NameObj.SetActive(true);
                player2NameObj.SetActive(true);
                player3NameObj.SetActive(true);
                player4NameObj.SetActive(true);
                monitorRow1.SetActive(true);
                monitorRow2.SetActive(true);
                monitorRow3.SetActive(true);
                monitorRow4.SetActive(true);
            }
        }
        if (initStage == 3) //Välj spelare 1 klot och ball selector in
        {
            //Animera kameran att visa klot
            nameMenuAnimator.SetTrigger("Names Out");
            ballMenu.SetActive(true);
            redBall.GetComponent<BallBehaviour>().highlightBall();
            mainCamera.GetComponent<Animator>().SetTrigger("Ball Selector");
            playerNameDisplay.text = ("CHOOSE " + gameManager.GetComponent<gameManagementScript>().player1Name + "'S BALL");
        }
        if (initStage == 4) //Välj spelare 2 klot
        { 
            player1Ball = gameManager.GetComponent<gameManagementScript>().currentBallID;
            playerNameDisplay.text = ("CHOOSE " + gameManager.GetComponent<gameManagementScript>().player2Name + "'S BALL");
            if (player1Ball == 0) 
            { 
                redBall.GetComponent<BallBehaviour>().select();
            }
            if (player1Ball == 1)
            {
                orangeBall.GetComponent<BallBehaviour>().select();
            }
            if (player1Ball == 2)
            {
                blueBall.GetComponent<BallBehaviour>().select();
            }
            if (player1Ball == 3)
            {
                pinkBall.GetComponent<BallBehaviour>().select();
            }
        }
        if (initStage == 5) //Välj spelare 3 klot
        {
            player2Ball = gameManager.GetComponent<gameManagementScript>().currentBallID;
            playerNameDisplay.text = ("CHOOSE " + gameManager.GetComponent<gameManagementScript>().player3Name + "'S BALL");
            if (player2Ball == 0)
            {
                redBall.GetComponent<BallBehaviour>().select();
            }
            if (player2Ball == 1)
            {
                orangeBall.GetComponent<BallBehaviour>().select();
            }
            if (player2Ball == 2)
            {
                blueBall.GetComponent<BallBehaviour>().select();
            }
            if (player2Ball == 3)
            {
                pinkBall.GetComponent<BallBehaviour>().select();
            }
        }
        if (initStage == 6) //Välj spelare 4 klot
        { 
            player3Ball = gameManager.GetComponent<gameManagementScript>().currentBallID;
            playerNameDisplay.text = ("CHOOSE " + gameManager.GetComponent<gameManagementScript>().player4Name + "'S BALL");
            if (player3Ball == 0)
            {
                redBall.GetComponent<BallBehaviour>().select();
            }
            if (player3Ball == 1)
            {
                orangeBall.GetComponent<BallBehaviour>().select();
            }
            if (player3Ball == 2)
            {
                blueBall.GetComponent<BallBehaviour>().select();
            }
            if (player3Ball == 3)
            {
                pinkBall.GetComponent<BallBehaviour>().select();
            }
        }
        if (initStage == 7)
        {
            player4Ball = gameManager.GetComponent<gameManagementScript>().currentBallID;
            if (player4Ball == 0)
            {
                redBall.GetComponent<BallBehaviour>().select();
            }
            if (player4Ball == 1)
            {
                orangeBall.GetComponent<BallBehaviour>().select();
            }
            if (player4Ball == 2)
            {
                blueBall.GetComponent<BallBehaviour>().select();
            }
            if (player4Ball == 3)
            {
                pinkBall.GetComponent<BallBehaviour>().select();
            }
        }
        if (initStage == 3 + gameManager.GetComponent<gameManagementScript>().playerAmount) //Spelet Börjar
        {
            ballMenuAnimator.SetTrigger("Ball Out");
            gameManager.GetComponent<gameManagementScript>().returnAllActivatedBalls();
            gameManager.GetComponent<gameManagementScript>().initializeNextTurn(); //Påbörja Match
            initializationMenu.SetActive(false);
        }
    }
    public void plusAmountButton()
    {
        gameManager.GetComponent<gameManagementScript>().playerAmount++;
        updateUI();
    }
    public void minusAmountButton()
    {
        gameManager.GetComponent<gameManagementScript>().playerAmount--;  
        updateUI();
    }
    void updateUI()
    {
        if (gameManager.GetComponent<gameManagementScript>().playerAmount == 4)
        {
            playeramountMinus.interactable = true;
            playeramountPlus.interactable = false;
        }
        if (gameManager.GetComponent<gameManagementScript>().playerAmount == 2)
        {
            playeramountMinus.interactable = false;
            playeramountPlus.interactable = true;
        }
        if (gameManager.GetComponent<gameManagementScript>().playerAmount == 3)
        {
            playeramountMinus.interactable = true;
            playeramountPlus.interactable = true;
        }
        playerAmountDisplay.text = gameManager.GetComponent<gameManagementScript>().playerAmount.ToString();
    }
    public Text monitorName1;
    public Text monitorName2;
    public Text monitorName3;
    public Text monitorName4;
    public void ReadPlayer1Name(string s)
    {
        s = s.ToUpper();
        gameManager.GetComponent<gameManagementScript>().player1Name = s;
        monitorName1.text = s;
    }
    public void ReadPlayer2Name(string s)
    {
        s = s.ToUpper();
        gameManager.GetComponent<gameManagementScript>().player2Name = s;
        monitorName2.text = s;
    }
    public void ReadPlayer3Name(string s)
    {
        s = s.ToUpper();
        gameManager.GetComponent<gameManagementScript>().player3Name = s;
        monitorName3.text = s;
    }
    public void ReadPlayer4Name(string s)
    {
        s = s.ToUpper();
        gameManager.GetComponent<gameManagementScript>().player4Name = s;
        monitorName4.text = s;
    }
    
    //##### Shot Menu #####
    public void nextMenuButton()
    {
        shotMenuStage++;
        updateShotMenu();
    }
    public void previousMenuButton()
    {
        shotMenuStage--;
        updateShotMenu();
    }
    public bool aimOpen;
    public bool curveOpen;
    public bool forceOpen;
    public Button nextButton;
    public Button previousButton;
    public void updateShotMenu()
    {
        if (shotMenuStage == 1)
        {
            //Aim menu
            aimMenu.GetComponent<Animator>().SetTrigger("Aim In"); 
            aimOpen = true;
            if (curveOpen == true)
            {
                curveMenu.GetComponent<Animator>().SetTrigger("Curve Out");
                curveOpen = false;
            }
            nextButton.interactable = true;
            previousButton.interactable = false;
        }
        if (shotMenuStage == 2)
        {
            //Curve menu
            curveMenu.GetComponent<Animator>().SetTrigger("Curve In");
            curveOpen = true;
            if (aimOpen == true)
            {
                aimMenu.GetComponent<Animator>().SetTrigger("Aim Out");
                aimOpen = false;
            }
            if (forceOpen == true)
            {
                forceMenu.GetComponent<Animator>().SetTrigger("Force Out");
                forceOpen = false;
            }
            nextButton.interactable = true;
            previousButton.interactable = true;
        }
        if (shotMenuStage == 3)
        {
            //Force menu
            forceMenu.GetComponent<Animator>().SetTrigger("Force In");
            forceOpen = true;
            if (curveOpen == true)
            {
                curveMenu.GetComponent<Animator>().SetTrigger("Curve Out");
                curveOpen = false;
            }
            nextButton.interactable = false;
            previousButton.interactable = true;
        }
    }
    public void closeShotMenu()
    {
        shotMenu.GetComponent<Animator>().SetTrigger("Shot Out");
    }

    //Aim menu
    public Toggle aimAddition;
    public Toggle aimSubtraction;
    public Toggle aimMultiplication;
    public Toggle aimDivision;
    public Toggle curveAddition;
    public Toggle curveSubtraction;
    public Toggle curveMultiplication;
    public Toggle curveDivision;
    public Toggle forceAddition;
    public Toggle forceSubtraction;
    public Toggle forceMultiplication;
    public Toggle forceDivision;
    public Toggle aimInvert;
    public Toggle curveInvert;
    public float aimSum;
    public float curveSum;
    public float forceSum;
    public Text aimSumText;
    public Text curveSumText;
    public Text forceSumText;
    public bool selectedAim;
    public void aimAdditionTicked(bool toggled)
    {
        aimSum = gameManager.GetComponent<gameManagementScript>().rand11 + gameManager.GetComponent<gameManagementScript>().rand12;
        aimSumText.text = "= " + aimSum.ToString();
        if (toggled == true)
        {
            aimAddition.interactable = true;
            aimSubtraction.interactable = false;
            aimMultiplication.interactable = false;
            aimDivision.interactable = false;
            aimInvert.interactable = true;
            aimSumText.fontSize = 150;
            selectedAim = true;
        }
        else
        {
            aimAddition.interactable = true;
            aimSubtraction.interactable = true;
            aimMultiplication.interactable = true;
            aimDivision.interactable = true;
            aimInvert.interactable = false; 
            aimInvert.isOn = false;  
            aimSumText.text = "select method";
            aimSumText.fontSize = 75;
            selectedAim = false;
        }
        gameManager.GetComponent<gameManagementScript>().updateShotAnchor();
    }
    public void aimSubtractionTicked(bool toggled)
    {
        aimSum = gameManager.GetComponent<gameManagementScript>().rand11 - gameManager.GetComponent<gameManagementScript>().rand12;
        aimSumText.text = "= " + aimSum.ToString();
        if (toggled == true)
        {
            aimAddition.interactable = false;
            aimSubtraction.interactable = true;
            aimMultiplication.interactable = false;
            aimDivision.interactable = false;
            aimInvert.interactable = true;
            aimSumText.fontSize = 150;
            selectedAim = true;
        }
        else
        {
            aimAddition.interactable = true;
            aimSubtraction.interactable = true;
            aimMultiplication.interactable = true;
            aimDivision.interactable = true;
            aimInvert.interactable = false; aimInvert.isOn = false;
            aimSumText.text = "select method";
            aimSumText.fontSize = 75;
            selectedAim = false;
        }
        gameManager.GetComponent<gameManagementScript>().updateShotAnchor();
    }
    public void aimMultiplicationTicked(bool toggled)
    {
        aimSum = gameManager.GetComponent<gameManagementScript>().rand11 * gameManager.GetComponent<gameManagementScript>().rand12;
        aimSumText.text = "= " + aimSum.ToString();
        if (toggled == true)
        {
            aimAddition.interactable = false;
            aimSubtraction.interactable = false;
            aimMultiplication.interactable = true;
            aimDivision.interactable = false;
            aimInvert.interactable = true;
            aimSumText.fontSize = 150;
            selectedAim = true;
        }
        else
        {
            aimAddition.interactable = true;
            aimSubtraction.interactable = true;
            aimMultiplication.interactable = true;
            aimDivision.interactable = true;
            aimInvert.interactable = false; aimInvert.isOn = false;
            aimSumText.text = "select method";
            aimSumText.fontSize = 75;
            selectedAim = false;
        }
        gameManager.GetComponent<gameManagementScript>().updateShotAnchor();
    }
    public void aimDivisionTicked(bool toggled)
    {
        aimSum = (float)gameManager.GetComponent<gameManagementScript>().rand11 / gameManager.GetComponent<gameManagementScript>().rand12;
        aimSumText.text = "= " + aimSum.ToString("F1");
        if (toggled == true)
        {
            aimAddition.interactable = false;
            aimSubtraction.interactable = false;
            aimMultiplication.interactable = false;
            aimDivision.interactable = true;
            aimInvert.interactable = true;
            aimSumText.fontSize = 150;
            selectedAim = true;
        }
        else
        {
            aimAddition.interactable = true;
            aimSubtraction.interactable = true;
            aimMultiplication.interactable = true;
            aimDivision.interactable = true;
            aimInvert.interactable = false; aimInvert.isOn = false;
            aimSumText.text = "select method";
            aimSumText.fontSize = 75;
            selectedAim = false;
        }
        gameManager.GetComponent<gameManagementScript>().updateShotAnchor();
    }
    public bool selectedCurve;
    public void curveAdditionTicked(bool toggled)
    {
        curveSum = gameManager.GetComponent<gameManagementScript>().rand21 + gameManager.GetComponent<gameManagementScript>().rand22;
        curveSumText.text = "= " + curveSum.ToString();
        if (toggled == true)
        {
            curveAddition.interactable = true;
            curveSubtraction.interactable = false;
            curveMultiplication.interactable = false;
            curveDivision.interactable = false;
            curveInvert.interactable = true;
            curveSumText.fontSize = 150;
            selectedCurve = true;
        }
        else
        {
            curveAddition.interactable = true;
            curveSubtraction.interactable = true;
            curveMultiplication.interactable = true;
            curveDivision.interactable = true;
            curveInvert.interactable = false; curveInvert.isOn = false;
            curveSumText.text = "select method";
            curveSumText.fontSize = 75;
            selectedCurve = false;
        }
        gameManager.GetComponent<gameManagementScript>().updateShotAnchor();
    }
    public void curveSubtractionTicked(bool toggled)
    {
        curveSum = gameManager.GetComponent<gameManagementScript>().rand21 - gameManager.GetComponent<gameManagementScript>().rand22;
        curveSumText.text = "= " + curveSum.ToString();
        if (toggled == true)
        {
            curveAddition.interactable = false;
            curveSubtraction.interactable = true;
            curveMultiplication.interactable = false;
            curveDivision.interactable = false;
            curveInvert.interactable = true;
            curveSumText.fontSize = 150;
            selectedCurve = true;
        }
        else
        {
            curveAddition.interactable = true;
            curveSubtraction.interactable = true;
            curveMultiplication.interactable = true;
            curveDivision.interactable = true;
            curveInvert.interactable = false; curveInvert.isOn = false;
            curveSumText.text = "select method";
            curveSumText.fontSize = 75;
            selectedCurve = false;
        }
        gameManager.GetComponent<gameManagementScript>().updateShotAnchor();
    }
    public void curveMultiplicationTicked(bool toggled)
    {
        curveSum = gameManager.GetComponent<gameManagementScript>().rand21 * gameManager.GetComponent<gameManagementScript>().rand22;
        curveSumText.text = "= " + curveSum.ToString();
        if (toggled == true)
        {
            curveAddition.interactable = false;
            curveSubtraction.interactable = false;
            curveMultiplication.interactable = true;
            curveDivision.interactable = false;
            curveInvert.interactable = true;
            curveSumText.fontSize = 150;
            selectedCurve = true;
        }
        else
        {
            curveAddition.interactable = true;
            curveSubtraction.interactable = true;
            curveMultiplication.interactable = true;
            curveDivision.interactable = true;
            curveInvert.interactable = false; curveInvert.isOn = false;
            curveSumText.text = "select method";
            curveSumText.fontSize = 75;
            selectedCurve = false;
        }
        gameManager.GetComponent<gameManagementScript>().updateShotAnchor();
    }
    public void curveDivisionTicked(bool toggled)
    {
        curveSum = (float)gameManager.GetComponent<gameManagementScript>().rand21 / gameManager.GetComponent<gameManagementScript>().rand22;
        curveSumText.text = "= " + curveSum.ToString("F1");
        if (toggled == true)
        {
            curveAddition.interactable = false;
            curveSubtraction.interactable = false;
            curveMultiplication.interactable = false;
            curveDivision.interactable = true;
            curveInvert.interactable = true;
            curveSumText.fontSize = 150;
            selectedCurve = true;
        }
        else
        {
            curveAddition.interactable = true;
            curveSubtraction.interactable = true;
            curveMultiplication.interactable = true;
            curveDivision.interactable = true;
            curveInvert.interactable = false; curveInvert.isOn = false;
            curveSumText.text = "select method";
            curveSumText.fontSize = 75;
            selectedCurve = false;
        }
        gameManager.GetComponent<gameManagementScript>().updateShotAnchor();
    }
    public bool selectedForce;
    public void forceAdditionTicked(bool toggled)
    {
        forceSum = gameManager.GetComponent<gameManagementScript>().rand31 + gameManager.GetComponent<gameManagementScript>().rand32;
        forceSumText.text = "= " + forceSum.ToString();
        if (toggled == true)
        {
            forceAddition.interactable = true;
            forceSubtraction.interactable = false;
            forceMultiplication.interactable = false;
            forceDivision.interactable = false;
            forceSumText.fontSize = 150;
            selectedForce = true;
        }
        else
        {
            forceAddition.interactable = true;
            forceSubtraction.interactable = true;
            forceMultiplication.interactable = true;
            forceDivision.interactable = true;
            forceSumText.text = "select method";
            forceSumText.fontSize = 75;
            selectedForce = false;
        }
        forceChecker();
        gameManager.GetComponent<gameManagementScript>().updateShotAnchor();
    }
    public void forceSubtractionTicked(bool toggled)
    {
        forceSum = gameManager.GetComponent<gameManagementScript>().rand31 - gameManager.GetComponent<gameManagementScript>().rand32;
        forceSumText.text = "= " + forceSum.ToString();
        if (toggled == true)
        {
            forceAddition.interactable = false;
            forceSubtraction.interactable = true;
            forceMultiplication.interactable = false;
            forceDivision.interactable = false;
            forceSumText.fontSize = 150;
            selectedForce = true;
        }
        else
        {
            forceAddition.interactable = true;
            forceSubtraction.interactable = true;
            forceMultiplication.interactable = true;
            forceDivision.interactable = true;
            forceSumText.text = "select method";
            forceSumText.fontSize = 75;
            selectedForce = false;
        }
        forceChecker();
        gameManager.GetComponent<gameManagementScript>().updateShotAnchor();
    }
    public void forceMultiplicationTicked(bool toggled)
    {
        forceSum = gameManager.GetComponent<gameManagementScript>().rand31 * gameManager.GetComponent<gameManagementScript>().rand32;
        forceSumText.text = "= " + forceSum.ToString();
        if (toggled == true)
        {
            forceAddition.interactable = false;
            forceSubtraction.interactable = false;
            forceMultiplication.interactable = true;
            forceDivision.interactable = false;
            forceSumText.fontSize = 150;
            selectedForce = true;
        }
        else
        {
            forceAddition.interactable = true;
            forceSubtraction.interactable = true;
            forceMultiplication.interactable = true;
            forceDivision.interactable = true;
            forceSumText.text = "select method";
            forceSumText.fontSize = 75;
            selectedForce = false;
        }
        forceChecker();
        gameManager.GetComponent<gameManagementScript>().updateShotAnchor();
    }
    public void forceDivisionTicked(bool toggled)
    {
        forceSum = (float)gameManager.GetComponent<gameManagementScript>().rand31 / gameManager.GetComponent<gameManagementScript>().rand32;
        forceSumText.text = "= " + forceSum.ToString("F1");
        if (toggled == true)
        {
            forceAddition.interactable = false;
            forceSubtraction.interactable = false;
            forceMultiplication.interactable = false;
            forceDivision.interactable = true;
            forceSumText.fontSize = 150;
            selectedForce = true;
        }
        else
        {
            forceAddition.interactable = true;
            forceSubtraction.interactable = true;
            forceMultiplication.interactable = true;
            forceDivision.interactable = true;
            forceSumText.text = "select method";
            forceSumText.fontSize = 75;
            selectedForce = false;
        }
        forceChecker();
        gameManager.GetComponent<gameManagementScript>().updateShotAnchor();
    }
    public void aimInverted(bool ticked)
    {
        aimSum = aimSum * -1;
        aimSumText.text = "= " + aimSum.ToString("F1");
        gameManager.GetComponent<gameManagementScript>().updateShotAnchor();
    }
    public void curveInverted(bool ticked)
    {
        curveSum = curveSum * -1;
        curveSumText.text = "= " + curveSum.ToString("F1");
        gameManager.GetComponent<gameManagementScript>().updateShotAnchor();
    }
    void forceChecker()
    {
        if (forceSum < 0)
        {
            forceSum = forceSum * -1;
            forceSumText.text = "= " + forceSum.ToString("F1");
        }
        gameManager.GetComponent<gameManagementScript>().updateShotAnchor();
    }
    public GameObject followCamera;
    public bool ongoingShot;
    public BoxCollider rollbackBlock;
    public void bowlButton()
    {
        redBall.GetComponent<BallBehaviour>().bowl();
        orangeBall.GetComponent<BallBehaviour>().bowl();
        blueBall.GetComponent<BallBehaviour>().bowl();
        pinkBall.GetComponent<BallBehaviour>().bowl();
        //Kamera
        mainCamera.SetActive(false); followCamera.SetActive(true);
        ongoingShot = true;
        rollbackBlock.enabled = false;
        closeShotMenu();
    }
    public Text player1Score1;
    public Text player1Score2;
    public Text player1Score3;
    public Text player1Score4;
    public Text player2Score1;
    public Text player2Score2;
    public Text player2Score3;
    public Text player2Score4;
    public Text player3Score1;
    public Text player3Score2;
    public Text player3Score3;
    public Text player3Score4;
    public Text player4Score1;
    public Text player4Score2;
    public Text player4Score3;
    public Text player4Score4;
    public Text player1totalText;
    public Text player2totalText;
    public Text player3totalText;
    public Text player4totalText;
    public int p1r1;
    public int p1r2;
    public int p1r3;
    public int p1r4;
    public int p2r1;
    public int p2r2;
    public int p2r3;
    public int p2r4;
    public int p3r1;
    public int p3r2;
    public int p3r3;
    public int p3r4;
    public int p4r1;
    public int p4r2;
    public int p4r3;
    public int p4r4;
    public int player1Total;
    public int player2Total;
    public int player3Total;
    public int player4Total;
    
    public void updateScoreboard()
    {
        if (gameManager.GetComponent<gameManagementScript>().round == 1)
        {
            if (gameManager.GetComponent<gameManagementScript>().turn == 1)
            {
                p1r1 = gameManager.GetComponent<gameManagementScript>().fallenPins;
            }
            if (gameManager.GetComponent<gameManagementScript>().turn == 2)
            {
                p2r1 = gameManager.GetComponent<gameManagementScript>().fallenPins;
            }
            if (gameManager.GetComponent<gameManagementScript>().turn == 3)
            {
                p3r1 = gameManager.GetComponent<gameManagementScript>().fallenPins;
            }
            if (gameManager.GetComponent<gameManagementScript>().turn == 4)
            {
                p4r1 = gameManager.GetComponent<gameManagementScript>().fallenPins;
            }
        }
        if (gameManager.GetComponent<gameManagementScript>().round == 2)
        {
            if (gameManager.GetComponent<gameManagementScript>().turn == 1)
            {
                p1r2 = gameManager.GetComponent<gameManagementScript>().fallenPins;
            }
            if (gameManager.GetComponent<gameManagementScript>().turn == 2)
            {
                p2r2 = gameManager.GetComponent<gameManagementScript>().fallenPins;
            }
            if (gameManager.GetComponent<gameManagementScript>().turn == 3)
            {
                p3r2 = gameManager.GetComponent<gameManagementScript>().fallenPins;
            }
            if (gameManager.GetComponent<gameManagementScript>().turn == 4)
            {
                p4r2 = gameManager.GetComponent<gameManagementScript>().fallenPins;
            }
        }
        if (gameManager.GetComponent<gameManagementScript>().round == 3)
        {
            if (gameManager.GetComponent<gameManagementScript>().turn == 1)
            {
                p1r3 = gameManager.GetComponent<gameManagementScript>().fallenPins;
            }
            if (gameManager.GetComponent<gameManagementScript>().turn == 2)
            {
                p2r3 = gameManager.GetComponent<gameManagementScript>().fallenPins;
            }
            if (gameManager.GetComponent<gameManagementScript>().turn == 3)
            {
                p3r3 = gameManager.GetComponent<gameManagementScript>().fallenPins;
            }
            if (gameManager.GetComponent<gameManagementScript>().turn == 4)
            {
                p4r3 = gameManager.GetComponent<gameManagementScript>().fallenPins;
            }
        }
        if (gameManager.GetComponent<gameManagementScript>().round == 4)
        {
            if (gameManager.GetComponent<gameManagementScript>().turn == 1)
            {
                p1r4 = gameManager.GetComponent<gameManagementScript>().fallenPins;
            }
            if (gameManager.GetComponent<gameManagementScript>().turn == 2)
            {
                p2r4 = gameManager.GetComponent<gameManagementScript>().fallenPins;
            }
            if (gameManager.GetComponent<gameManagementScript>().turn == 3)
            {
                p3r4 = gameManager.GetComponent<gameManagementScript>().fallenPins;
            }
            if (gameManager.GetComponent<gameManagementScript>().turn == 4)
            {
                p4r4 = gameManager.GetComponent<gameManagementScript>().fallenPins;
            }
        }
        player1Total = p1r1 + p1r2 + p1r3 + p1r4;
        player2Total = p2r1 + p2r2 + p2r3 + p2r4;
        player3Total = p3r1 + p3r2 + p3r3 + p3r4;
        player4Total = p4r1 + p4r2 + p4r3 + p4r4;
        
        player1Score1.text = p1r1.ToString();
        player1Score2.text = p1r2.ToString();
        player1Score3.text = p1r3.ToString();
        player1Score4.text = p1r4.ToString();

        player2Score1.text = p2r1.ToString();
        player2Score2.text = p2r2.ToString();
        player2Score3.text = p2r3.ToString();
        player2Score4.text = p2r4.ToString();

        player3Score1.text = p3r1.ToString();
        player3Score2.text = p3r2.ToString();
        player3Score3.text = p3r3.ToString();
        player3Score4.text = p3r4.ToString();

        player4Score1.text = p4r1.ToString();
        player4Score2.text = p4r2.ToString();
        player4Score3.text = p4r3.ToString();
        player4Score4.text = p4r4.ToString();

        player1totalText.text = player1Total.ToString();
        player2totalText.text = player2Total.ToString();
        player3totalText.text = player3Total.ToString();
        player4totalText.text = player4Total.ToString();
    }
}
