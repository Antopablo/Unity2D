using UnityEngine;

public class HealPowerUp : MonoBehaviour
{
    public int mHeathPoints;
    public AudioClip mPickUpSound;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if (PlayerHealth.instance.mCurrentHealth < PlayerHealth.instance.mMaxHealth)
            {
                AudioManager.instance.PlayClickAt(mPickUpSound, transform.position);
                PlayerHealth.instance.HealPlayer(mHeathPoints);
                Destroy(gameObject);
            }
        }
    }
}
