using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LoadingScrennBehaviour : MonoBehaviour
{
    public Slider loadingSlider;
    public bool allowEndAnim;
    public Animator handleAnim;
    public Animator pin1;
    public Animator pin2;
    public Animator pin3;
    public Animator FadeIn;
    public Animator FadeOut;
    public int rand1;
    public int rand2;
    public int rand3;
    public int rand4;
    public int rand5;

    private void Start()
    {
        StartCoroutine(startLoading());
        allowEndAnim = true;
        rand1 = Random.Range(1, 5);
        rand2 = Random.Range(1, 5);
        rand3 = Random.Range(1, 5);
        rand4 = Random.Range(1, 5);
        rand5 = Random.Range(1, 5);
    }

    IEnumerator startLoading()
    {
        yield return new WaitForSeconds(rand5);
        loadingSlider.value = loadingSlider.value + 2;
        yield return new WaitForSeconds(rand1);
        loadingSlider.value = loadingSlider.value + 42;
        loadingSlider.value = loadingSlider.value + 10;
        yield return new WaitForSeconds(rand2);
        loadingSlider.value = loadingSlider.value + 6;
        yield return new WaitForSeconds(rand3);
        loadingSlider.value = loadingSlider.value + 35;
        yield return new WaitForSeconds(rand4);
        loadingSlider.value = loadingSlider.value + 5;
    }

    private void Update()
    {
        if (loadingSlider.value == 100)
        {
            if (allowEndAnim == true)
            {
                allowEndAnim = false;
                handleAnim.SetTrigger("Strike");
                pin1.SetTrigger("Strike");
                pin2.SetTrigger("Strike");
                pin3.SetTrigger("Strike");
                //vänta 1 sekund och gå till spel
                StartCoroutine(wait1Sec());
            }
        }
    }

    IEnumerator wait1Sec()
    {
        yield return new WaitForSeconds(3);
        FadeOut.SetTrigger("Start");
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene(2);
    }
}
