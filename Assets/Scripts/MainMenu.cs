using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public string mLevelToLoad;
    public GameObject mSettingsWindow;

    public void OnStartGameClick ()
    {
        SceneManager.LoadScene(mLevelToLoad);
    }

    public void OnSettingsClick()
    {
        mSettingsWindow.SetActive(true);
    }

    public void OnCloseSettingsClick()
    {
        mSettingsWindow.SetActive(false);
    }

    public void OnCreditsClick()
    {
        SceneManager.LoadScene("Credits");
    }

    public void OnQuitGame()
    {
        Application.Quit();
    }

}
