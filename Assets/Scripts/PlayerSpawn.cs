using UnityEngine;

public class PlayerSpawn : MonoBehaviour
{
    private void Awake ()
    {
        GameObject.FindGameObjectWithTag("Player").transform.position = transform.position;
        //GameObject.FindGameObjectWithTag("MainCamera").transform.position = transform.position;
    }
}
