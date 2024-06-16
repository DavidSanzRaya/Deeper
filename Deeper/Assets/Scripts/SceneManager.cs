using UnityEngine;

public class SceneManager : MonoBehaviour
{
    public FadeIn fadeIn;

    public void LoadGame()
    {
        fadeIn.FadeInEffect();
        Invoke("OpenScene", 2.5f);
    }

    void OpenScene()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("Game");
    }

    public void Exit()
    {
        Application.Quit();
    }
}
