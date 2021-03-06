﻿using UnityEngine;

public class PlayerMovements : MonoBehaviour
{
    private Vector3 mVelocity = Vector3.zero;
    private bool mIsJumping;
    private bool mIsGrounded;
    [HideInInspector]
    public bool mIsClimbing;

    public Rigidbody2D mRb;
    public Animator mAnimator;
    public SpriteRenderer mSpriteRenderer;

    public float mMoveSpeed;
    public float mClimbSpeed;
    public float mJumpForce;
    private float mHorizontalMovement;
    private float mVerticallMovement;


    public Transform mGroundCheck;
    public float mGroundCheckRadius;
    public LayerMask mCollisionLayer;

    void Update()
    {
        if (Input.GetButtonDown("Jump") && mIsGrounded == true)
        {
            mIsJumping = true;
        }
        Flip(mRb.velocity.x);

        mAnimator.SetFloat("Speed", Mathf.Abs(mRb.velocity.x)); // Renvoie la valeur absolue de la valeur
        mAnimator.SetBool("IsClimbing", mIsClimbing);

        mHorizontalMovement = Input.GetAxis("Horizontal") * mMoveSpeed * Time.deltaTime;

    }

    void FixedUpdate()
    {
        mHorizontalMovement = Input.GetAxis("Horizontal") * mMoveSpeed * Time.deltaTime;
        mVerticallMovement = Input.GetAxis("Vertical") * mClimbSpeed * Time.deltaTime;

        mIsGrounded = Physics2D.OverlapCircle(mGroundCheck.position, mGroundCheckRadius, mCollisionLayer);

        MovePlayer(mHorizontalMovement, mVerticallMovement);
    }

    void MovePlayer(float _horizontalMovement, float _verticalMovement)
    {
        if (!mIsClimbing)
        {
            // déplacement horizontal
            Vector3 lTargetVelocity = new Vector2(_horizontalMovement, mRb.velocity.y);
            mRb.velocity = Vector3.SmoothDamp(mRb.velocity, lTargetVelocity, ref mVelocity, 0.05f);

            if (mIsJumping)
            {
                mRb.AddForce(new Vector2(0f, mJumpForce));
                mIsJumping = false;
            }
        } else
        {
            // déplacement vertical
            Vector3 lTargetVelocity = new Vector2(0, _verticalMovement);
            mRb.velocity = Vector3.SmoothDamp(mRb.velocity, lTargetVelocity, ref mVelocity, 0.05f);
        }

    }

    void Flip(float _velocity)
    {
        if (_velocity > 0.1f)
        {
            mSpriteRenderer.flipX = false;
        }
        else if (_velocity < -0.1f)
        {
            mSpriteRenderer.flipX = true;
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(mGroundCheck.position, mGroundCheckRadius);
    }
}
