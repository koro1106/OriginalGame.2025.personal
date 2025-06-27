using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCtrl : MonoBehaviour
{
    [SerializeField] public float speed = 3.0f;
    [SerializeField] public float jumpForce = 5.0f;
    public Animator animator;
    [SerializeField] private float groundDrag = 8f;//地上の空気抵抗
    [SerializeField] private float airDrag = 0f;//空中の空気抵抗
    private Rigidbody2D rb;
    private bool isRight = false;
    private bool isJumping = false;
    private bool isGround = true;
    private float dir = 1f;//移動方向

    void Start()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        Move();
    }
    void Update()
    {
        //向きの変更
        ChangeDirection();

        if (Input.GetKeyDown(KeyCode.Space) && !isJumping)
        {
            rb.velocity += new Vector2(0, jumpForce);
            animator.SetBool("IsJump", true);
            isJumping = true;
        }
    }

    void Move()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");

        //if (Mathf.Abs(horizontal) > 0 && Mathf.Abs(horizontal) < 0)
        //{
        //    animator.SetBool("IsWalking", true);
        //}
        //if (Mathf.Abs(horizontal) == 0)
        //{
        //    animator.SetBool("IsWalking", false);
        //}

        if (horizontal != 0f)
        {
            isRight = (horizontal > 0) ? true : false;
            dir = isRight ? 1f : -1f;

            Vector2 velocity = rb.velocity;
            velocity.x = horizontal * speed;
            rb.velocity = velocity;

            //入力値をanimatorで使うためにintにする
            int Horizontal = (int)Input.GetAxisRaw("Horizontal");
            animator.SetInteger("Speed", Mathf.Abs(Horizontal));
        }
        else
        {
            animator.SetInteger("Speed", 0);
        }
        if(horizontal == 0 && isJumping)
        {
            //空中で左右に動かせない仕様
            rb.velocity = new Vector2(0, rb.velocity.y);
        }
        rb.drag = isGround ? groundDrag : airDrag;
    }

    void ChangeDirection()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        Vector2 scale = transform.localScale;
        if (horizontal > 0)
        {
            //右向き
            scale.x = Mathf.Abs(scale.x);//絶対値(正)にする
        }
        else if (horizontal < 0)
        {
            //左向き
            scale.x = -Mathf.Abs(scale.x);//絶対値(負)にする
        }
        transform.localScale = scale;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isJumping = false;
            animator.SetBool("IsJump", false);
        }
    }
}
