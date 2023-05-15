using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuBehaviourScript : MonoBehaviour
{
    public Animator settingsAnim;
    public Animator mainAnim;
    public Animator transAnim;
    void Start()
    {
        
    }
    void Update()
    {
        
    }
    public void settingsButton()
    {
        settingsAnim.SetTrigger("Settings In");
        mainAnim.SetTrigger("Menu Out");
    }
    public void backButton()
    {
        settingsAnim.SetTrigger("Settings Out");
        mainAnim.SetTrigger("Menu In");
    }
    public void playButton()
    {
        transAnim.SetTrigger("Start");
        StartCoroutine(waitForTransition());
    }
    IEnumerator waitForTransition()
    {
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene(1);
    }
}
