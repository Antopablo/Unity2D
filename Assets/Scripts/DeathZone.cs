using System.Collections;
using UnityEngine;

public class DeathZone : MonoBehaviour
{

    public AudioClip mDieSound;

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.CompareTag("Player"))
        {
            AudioManager.instance.PlayClickAt(mDieSound, transform.position);
            collider.transform.position = CurrentSceneManager.instance.mRespawnPoint;
        }
    }

   
}
