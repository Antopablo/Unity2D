using UnityEngine;

public class CurrentSceneManager : MonoBehaviour
{
    // Start is called before the first frame update
    public int mCoinsPickedUpInThisSceneCount;
    public Vector3 mRespawnPoint;
    public int mLevelToUnlock;

    public static CurrentSceneManager instance;
    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("Il y a plus d'une instance de CurrentSceneManager dans la scène.");
            return;
        }
        instance = this;

        mRespawnPoint = GameObject.FindGameObjectWithTag("Player").transform.position;
    }

}
