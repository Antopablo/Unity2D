using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class LoadSpecificScene : MonoBehaviour
{

    public string pSceneName;
    private Animator pFadeSystem;

    private void Awake()
    {
        pFadeSystem = GameObject.FindGameObjectWithTag("FadeSystem").GetComponent<Animator>();
    }

    private void OnTriggerEnter2D (Collider2D collider)
    {
        if (collider.CompareTag("Player")) 
        {
            StartCoroutine(LoadNextScene());
        }
    }

    public IEnumerator LoadNextScene()
    {
        LoadAndSaveData.instance.SaveData();
        pFadeSystem.SetTrigger("FadeIn");
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene(pSceneName);
    }
}
