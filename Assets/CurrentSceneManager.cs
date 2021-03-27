using UnityEngine;

public class CurrentSceneManager : MonoBehaviour
{
    // Start is called before the first frame update
    public bool isPlayerPresentByDefault = false;
    public int mCoinsPickedUpInThisSceneCount;

    public static CurrentSceneManager instance;
    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("Il y a plus d'une instance de CurrentSceneManager dans la scène.");
            return;
        }
        instance = this;
    }

}
