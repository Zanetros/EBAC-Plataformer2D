using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using DG.Tweening;

public class Player : MonoBehaviour
{
    public Rigidbody2D MyRigidbody;

    public float speed;
    public float speedRun;

    private float _currentSpeed;

    public float forceJump = 2;

    public Vector2 friction = new Vector2(0.1f, 0);

    [Header("Animação")]
    public float jumpScaleY = 1.5f;
    public float jumpScaleX = 0.7f;
    public float animationDuration = 3f;
    public Ease ease = Ease.OutBack;
    Animator animator;

    public void Awake()
    {
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        HandleJump();
        HandleMovement();
    }

    private void HandleMovement()
    {
        if (Input.GetKey(KeyCode.LeftControl))
        {
            _currentSpeed = speedRun;
            animator.SetBool("Run", true);
            animator.speed = 1.25f;
        }
        else
        {
            _currentSpeed = speed;
            animator.SetBool("Run", false);
            animator.speed = 1f;
        }

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            MyRigidbody.velocity = new Vector2(-_currentSpeed, MyRigidbody.velocity.y);
            if (MyRigidbody.transform.localScale.x != -1)
            {
                MyRigidbody.transform.DOScaleX(-1, 0.1f);
            }
            animator.SetBool("Run", true);
        }

        else if (Input.GetKey(KeyCode.RightArrow))
        {
            MyRigidbody.velocity = new Vector2(_currentSpeed, MyRigidbody.velocity.y);
            if (MyRigidbody.transform.localScale.x != 1)
            {
                MyRigidbody.transform.DOScaleX(1, 0.1f);
            }
            animator.SetBool("Run", true);
        }

        else
        {
            animator.SetBool("Run", false);
        }
        
        if (MyRigidbody.velocity.x > 0)
        {
            MyRigidbody.velocity += friction;
        }

        else if (MyRigidbody.velocity.x < 0)
        {
            MyRigidbody.velocity -= friction;
        }
    }

    private void HandleJump()
    {
        StartCoroutine(JumpDelay());  
    }

    private void HandleScaleJump()
    {
        MyRigidbody.transform.DOScaleY(jumpScaleY, animationDuration).SetLoops(2, LoopType.Yoyo).SetEase(ease);
        MyRigidbody.transform.DOScaleX(jumpScaleX, animationDuration).SetLoops(2, LoopType.Yoyo).SetEase(ease);
    }

    public IEnumerator JumpDelay()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            MyRigidbody.velocity = Vector2.up * forceJump;
            MyRigidbody.transform.localScale = Vector2.one;

            DOTween.Kill(MyRigidbody.transform);
            animator.SetBool("Jump", true);
            HandleScaleJump();
            yield return new WaitForSeconds(0.4f);
            animator.SetBool("Jump", false);
        }

        
    }
}
