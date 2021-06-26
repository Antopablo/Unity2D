using System.Collections;
using UnityEngine;

public class DeathZone : MonoBehaviour
{


   private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.CompareTag("Player"))
        {
            collider.transform.position = CurrentSceneManager.instance.mRespawnPoint;
        }
    }

   
}
