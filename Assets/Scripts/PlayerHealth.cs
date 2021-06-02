using UnityEngine;
using System.Collections;

public class PlayerHealth : MonoBehaviour
{

    public int mMaxHealth = 100;
    public int mCurrentHealth;

    public float mInvincibleTimeAfterHit = 2f;
    public bool mIsInvincible = false;
    public float mInvisibilityFlashDelay = 0.2f;

    public SpriteRenderer mGraphics;
    public HealthBar mHealthbar;
    public static PlayerHealth instance;

    public AudioClip mHitSound;
    public AudioClip mDieSound;

    //Singleton
    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("Il y a plus d'une instance de PlayerHealth dans la scène.");
            return;
        }
        instance = this;
    }

    void Start()
    {
        mCurrentHealth = mMaxHealth;
        mHealthbar.setMaxHealth(mMaxHealth);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.H))
        {
            TakeDamage(110);
        }
    }

    public void TakeDamage(int _damage)
    {
        if (!mIsInvincible)
        {
            AudioManager.instance.PlayClickAt(mHitSound, transform.position);
            mCurrentHealth -= _damage;
            mHealthbar.setHealth(mCurrentHealth);

            if (mCurrentHealth <= 0)
            {
                Die();
                return;
            }

            mIsInvincible = true;
            StartCoroutine(InvincibilityFlash());
            StartCoroutine(HandleInvincibleDelay());
        }
    }

    public void HealPlayer(int _amount)
    {
        if ((mCurrentHealth + _amount) > mMaxHealth)
        {
            mCurrentHealth = mMaxHealth;
        } else
        {
            mCurrentHealth += _amount;
        }

        mHealthbar.setHealth(mCurrentHealth);

    }

    public void Die()
    {

        AudioManager.instance.PlayClickAt(mDieSound, transform.position);
        //Je désactive le script de mouvement
        PlayerMovements.instance.enabled = false;

        PlayerMovements.instance.mAnimator.SetTrigger("Die");
        PlayerMovements.instance.mRb.bodyType = RigidbodyType2D.Static;
        //PlayerMovements.instance.mRb.velocity = Vector3.zero;
        PlayerMovements.instance.mPlayerColider.enabled = false;

        GameOverManager.instance.OnPlayerDeath();
    }

    public void Respawn()
    {
        PlayerMovements.instance.enabled = true;

        PlayerMovements.instance.mAnimator.SetTrigger("Respawn");
        PlayerMovements.instance.mRb.bodyType = RigidbodyType2D.Dynamic;
        PlayerMovements.instance.mPlayerColider.enabled = true;
        mCurrentHealth = mMaxHealth;
        mHealthbar.setHealth(mCurrentHealth);
    }

    public IEnumerator InvincibilityFlash()
    {
        while (mIsInvincible)
        {
            mGraphics.color = new Color(1f, 1f, 1f, 0f);
            yield return new WaitForSeconds(mInvisibilityFlashDelay);
            mGraphics.color = new Color(1f, 1f, 1f, 1f);
            yield return new WaitForSeconds(mInvisibilityFlashDelay);
        }
    }

    public IEnumerator HandleInvincibleDelay()
    {
        yield return new WaitForSeconds(mInvincibleTimeAfterHit);
        mIsInvincible = false;
    }

}
