
using UnityEngine;

public class PickUpObject : MonoBehaviour
{

    //public AudioSource mAudioSource;
    public AudioClip mSound;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            AudioSource.PlayClipAtPoint(mSound, transform.position);
            Inventory.instance.AddCoin(1);
            CurrentSceneManager.instance.mCoinsPickedUpInThisSceneCount++;
            Destroy(gameObject);
        }
    } 
}
