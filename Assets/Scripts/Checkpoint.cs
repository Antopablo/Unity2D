using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    private Transform mPlayerSpawn;


    private void Awake()
    {
        mPlayerSpawn = GameObject.FindGameObjectWithTag("PlayerSpawn").transform;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            mPlayerSpawn.position = transform.position;
            gameObject.GetComponent<BoxCollider2D>().enabled = false;
        }
    }

}
