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
        Invoke("activatePantalla2", 8f);
    }

    public void activatePantalla2()
    {
        Invoke("startFadeIn", 8f);
        pantalla1.SetActive(false);
        pantalla2.SetActive(true);
        Invoke("LoadMainMenu", 10f);
    }

    public void LoadMainMenu()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("Menu");
    }

    public void startFadeIn()
    {
        fadeIn.FadeInEffect();
    }


}