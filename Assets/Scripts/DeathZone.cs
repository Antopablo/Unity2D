using UnityEngine;

public class DeathZone : MonoBehaviour
{

    private Transform mPlayerSpawn;

    private void Awake()
    {
        mPlayerSpawn = GameObject.FindGameObjectWithTag("PlayerSpawn").transform;
    }

   private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.CompareTag("Player"))
        {
            collider.transform.position = mPlayerSpawn.position;
        }
    }
}
