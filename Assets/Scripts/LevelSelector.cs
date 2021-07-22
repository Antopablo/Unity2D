using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class LevelSelector : MonoBehaviour
{

    public Button[] mLevelButtons;

    public void Start()
    {

        int lLevelReached = PlayerPrefs.GetInt("levelReached", 1);

        for (int i = 0; i < mLevelButtons.Length; i++)
        {
            if (i + 1 > lLevelReached)
            {
                mLevelButtons[i].interactable = false;
            }
        }
    }

    public void LoadLevelPassed(string pLevelName)
    {
        SceneManager.LoadScene(pLevelName);
    }
}
