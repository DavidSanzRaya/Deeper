using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class PlayButton : MonoBehaviour
{
    public FadeIn fadeIn;

    public void Play()
    {
        fadeIn.FadeInEffect();
        Invoke("OpenScene", 2.5f);

    }

    void OpenScene()
    {
        SceneManager.LoadScene("nivel1");
    }

}
