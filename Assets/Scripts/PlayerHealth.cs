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
            TakeDamage(20);
        }
    }

    public void TakeDamage(int _damage)
    {
        if (!mIsInvincible)
        {
            mCurrentHealth -= _damage;
            mHealthbar.setHealth(mCurrentHealth);
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
