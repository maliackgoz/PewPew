using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{
    public void OnPlayButton()
    {
        SceneManager.LoadScene("MainScene");
    }

    public void OnQuitButton()
    {
        Debug.Log("You are exitting from the game!");
        Application.Quit();
    }
}