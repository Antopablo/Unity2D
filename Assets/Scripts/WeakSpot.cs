using UnityEngine;

public class WeakSpot : MonoBehaviour
{

    public GameObject objectToDestroy;
    public AudioClip mKillSound;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            AudioManager.instance.PlayClickAt(mKillSound, transform.position);
            Destroy(objectToDestroy);
        }
         
    }
}
