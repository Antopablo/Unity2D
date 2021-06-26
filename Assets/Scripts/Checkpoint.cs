using UnityEngine;

public class Checkpoint : MonoBehaviour
{
   
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            //AudioManager.instance.PlayClickAt(mCheckpointReachedSound, transform.position);
            CurrentSceneManager.instance.mRespawnPoint = transform.position;
            gameObject.GetComponent<BoxCollider2D>().enabled = true;
        }
    }

}
