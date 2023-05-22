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
            }
            if (gameManager.GetComponent<gameManagementScript>().playerAmount == 2)
            {
                player1NameObj.SetActive(true);
                player2NameObj.SetActive(true);
                player3NameObj.SetActive(false);
                player4NameObj.SetActive(false);
            }
            if (gameManager.GetComponent<gameManagementScript>().playerAmount == 3)
            {
                player1NameObj.SetActive(true);
                player2NameObj.SetActive(true);
                player3NameObj.SetActive(true);
                player4NameObj.SetActive(false);
            }
            if (gameManager.GetComponent<gameManagementScript>().playerAmount == 4)
            {
                player1NameObj.SetActive(true);
                player2NameObj.SetActive(true);
                player3NameObj.SetActive(true);
                player4NameObj.SetActive(true);
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
        if (gameManager.GetComponent<gameManagementScript>().playerAmount == 1) 
        {
            playeramountMinus.interactable = false; 
            playeramountPlus.interactable = true;
        }
        if (gameManager.GetComponent<gameManagementScript>().playerAmount == 4)
        {
            playeramountMinus.interactable = true;
            playeramountPlus.interactable = false;
        }
        if (gameManager.GetComponent<gameManagementScript>().playerAmount == 2)
        {
            playeramountMinus.interactable = true;
            playeramountPlus.interactable = true;
        }
        if (gameManager.GetComponent<gameManagementScript>().playerAmount == 3)
        {
            playeramountMinus.interactable = true;
            playeramountPlus.interactable = true;
        }
        playerAmountDisplay.text = gameManager.GetComponent<gameManagementScript>().playerAmount.ToString();
    }
    public void ReadPlayer1Name(string s)
    {
        s = s.ToUpper();
        gameManager.GetComponent<gameManagementScript>().player1Name = s;
    }
    public void ReadPlayer2Name(string s)
    {
        s = s.ToUpper();
        gameManager.GetComponent<gameManagementScript>().player2Name = s;
    }
    public void ReadPlayer3Name(string s)
    {
        s = s.ToUpper();
        gameManager.GetComponent<gameManagementScript>().player3Name = s;
    }
    public void ReadPlayer4Name(string s)
    {
        s = s.ToUpper();
        gameManager.GetComponent<gameManagementScript>().player4Name = s;
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
    bool aimOpen;
    bool curveOpen;
    bool forceOpen;
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
    public void bowlButton()
    {
        redBall.GetComponent<BallBehaviour>().bowl();
        orangeBall.GetComponent<BallBehaviour>().bowl();
        blueBall.GetComponent<BallBehaviour>().bowl();
        pinkBall.GetComponent<BallBehaviour>().bowl();
    }
}
