
using UnityEngine;

public class PickUpObject : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Inventory.instance.AddCoin(1);
            CurrentSceneManager.instance.mCoinsPickedUpInThisSceneCount++;
            Destroy(gameObject);
        }
    } 
}
