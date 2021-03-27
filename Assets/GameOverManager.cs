using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverManager : MonoBehaviour
{

    public GameObject mGameOverUI;
    public static GameOverManager instance;

    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("Il y a plus d'une instance de GameOverManager dans la scène.");
            return;
        }
        instance = this;
    }
    public void OnPlayerDeath()
    {
        if (CurrentSceneManager.instance.isPlayerPresentByDefault)
        {
            DontDestroyOnLoadScene.instance.RemoveFromDontDestroyOnLoad();
        }

        mGameOverUI.SetActive(true);
    }

    public void OnRetryButtonClick()
    {
        Inventory.instance.RemoveCoin(CurrentSceneManager.instance.mCoinsPickedUpInThisSceneCount);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        PlayerHealth.instance.Respawn();
        mGameOverUI.SetActive(false);
    }

    public void OnMainMenuButtonClick()
    {

    }

    public void OnQuitButtonClick()
    {
        Application.Quit();
    }

}
