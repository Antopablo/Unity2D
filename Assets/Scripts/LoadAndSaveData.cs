using UnityEngine;

public class LoadAndSaveData : MonoBehaviour
{
    public static LoadAndSaveData instance;
    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("Il y a plus d'une instance de LoadAndSaveData dans la scène.");
            return;
        }
        instance = this;
    }


    // Start is called before the first frame update
    void Start()
    {
        Inventory.instance.mCoinsCount = PlayerPrefs.GetInt("coinsCount", 0);
        Inventory.instance.UpdateTextUI();

        //Sauvegarde la vie entres niveaux
        /*int lCurrentHealth = PlayerPrefs.GetInt("playerHealth", PlayerHealth.instance.mMaxHealth);
        PlayerHealth.instance.mCurrentHealth = lCurrentHealth;
        PlayerHealth.instance.mHealthbar.setHealth(lCurrentHealth);*/
    }

    public void SaveData()
    {
        PlayerPrefs.SetInt("coinsCount", Inventory.instance.mCoinsCount);
        // enregistre uniquement si niveau débloqué > au niveau déjà débloqué
        if (CurrentSceneManager.instance.mLevelToUnlock > PlayerPrefs.GetInt("levelReached",1))
        {
            PlayerPrefs.SetInt("levelReached", CurrentSceneManager.instance.mLevelToUnlock);
        }

        //Sauvegarde la vie entres niveaux
        //PlayerPrefs.SetInt("playerHealth", PlayerHealth.instance.mCurrentHealth);
    }


}
