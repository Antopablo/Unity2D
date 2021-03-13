using UnityEngine;

public class EnemyPatrol : MonoBehaviour
{
    // Start is called before the first frame update

    public float mSpeed;
    public int mDamageOnCollision = 100;

    public Transform[] mWayPoints;

    public SpriteRenderer mSpriteRenderer;
    private Transform mTarget;
    private int mDestPoint = 0;


    void Start()
    {
        mTarget = mWayPoints[0];
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 lDir = mTarget.position - transform.position;
        transform.Translate(lDir.normalized * mSpeed * Time.deltaTime, Space.World);

        // Si l'ennemi est arrivé à destination
        if (Vector3.Distance(transform.position, mTarget.position) < 0.3f)
        {
            mDestPoint = (mDestPoint + 1) % mWayPoints.Length;
            mTarget = mWayPoints[mDestPoint];
            mSpriteRenderer.flipX = !mSpriteRenderer.flipX;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.CompareTag("Player"))
        {
            PlayerHealth lPlayerHealth = collision.transform.GetComponent<PlayerHealth>();
            lPlayerHealth.TakeDamage(mDamageOnCollision);
        }
    }


}
