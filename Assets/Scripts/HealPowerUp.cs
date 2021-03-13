using UnityEngine;

public class HealPowerUp : MonoBehaviour
{
    public int mHeathPoints;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if (PlayerHealth.instance.mCurrentHealth < PlayerHealth.instance.mMaxHealth)
            {
                PlayerHealth.instance.HealPlayer(mHeathPoints);
                Destroy(gameObject);
            }
        }
    }
}
