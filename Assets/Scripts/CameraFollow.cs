using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public GameObject mPlayer;
    public float timeOffset;
    public Vector3 posoffeset;

    private Vector3 mVelocity;

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.SmoothDamp(transform.position, mPlayer.transform.position + posoffeset, ref mVelocity, timeOffset);
    }
}
