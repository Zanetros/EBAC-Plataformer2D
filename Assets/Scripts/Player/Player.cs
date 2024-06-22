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
        }
        else
        {
            _currentSpeed = speed;
        }

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            MyRigidbody.velocity = new Vector2(-_currentSpeed, MyRigidbody.velocity.y);
        }

        else if (Input.GetKey(KeyCode.RightArrow))
        {
            MyRigidbody.velocity = new Vector2(_currentSpeed, MyRigidbody.velocity.y);
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
        if (Input.GetKeyDown(KeyCode.Space))
        {
            MyRigidbody.velocity = Vector2.up * forceJump; 
            MyRigidbody.transform.localScale = Vector2.one;

            DOTween.Kill(MyRigidbody.transform);

            HandleScaleJump();
        }          
    }

    private void HandleScaleJump()
    {
        MyRigidbody.transform.DOScaleY(jumpScaleY, animationDuration).SetLoops(2, LoopType.Yoyo).SetEase(ease);
        MyRigidbody.transform.DOScaleX(jumpScaleX, animationDuration).SetLoops(2, LoopType.Yoyo).SetEase(ease);
    }
}
