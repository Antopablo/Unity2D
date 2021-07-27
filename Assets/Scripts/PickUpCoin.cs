
using UnityEngine;

public class PickUpCoin : MonoBehaviour
{

    public AudioClip mSound;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            AudioManager.instance.PlayClickAt(mSound, transform.position);
            Inventory.instance.AddCoin(1);
            CurrentSceneManager.instance.mCoinsPickedUpInThisSceneCount++;
            Destroy(gameObject);
        }
    } 
}
