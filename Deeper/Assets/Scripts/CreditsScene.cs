using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CreditsScene : MonoBehaviour
{
    public GameObject pantalla1;
    public GameObject pantalla2;

    public FadeIn fadeIn;

    void Start()
    {
        fadeIn.FadeOut();
        Invoke("callFadeIn", 10f);
    }

    void callFadeIn()
    {
        fadeIn.FadeInEffect();
        Invoke("activatePantalla2", 1.5f);

    }

    void callFadeOut()
    {
        fadeIn.FadeInEffect();
        Invoke("LoadMainMenu", 1f);

    }

    public void activatePantalla2()
    {
        fadeIn.FadeOut();
        pantalla1.SetActive(false);
        pantalla2.SetActive(true);
        Invoke("callFadeOut", 8f);
    }

    public void LoadMainMenu()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("Menu");
    }


}