using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelSelector : MonoBehaviour
{
    public void LoadLevelPassed(string pLevelName)
    {
        SceneManager.LoadScene(pLevelName);
    }
}
