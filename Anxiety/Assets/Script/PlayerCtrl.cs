using UnityEngine;

public class PlayerCtrl : MonoBehaviour
{
    [SerializeField] public float speed = 50.0f;
    [SerializeField] public float jumpForce = 65.0f;
    [SerializeField] private Transform holdPoint;
    [SerializeField] private Transform rayPoint;

    [SerializeField] public float holdIntensity = 0.25f; 
    [SerializeField] public float nomalIntensity = 1f; 
    [SerializeField] public float duration = 0.5f; 

    public Animator animator;
    private Rigidbody2D rb;
    private bool isRight = false;
    private bool isJumping = false;
    private bool isGround = true;
    public bool isHold = false;

    private float dir = 1f;
    private float rayDistans = 0.2f;
    private GameObject holdObj;
    RaycastHit2D hit;
    private VignetteCtrl vignette;
    private ColorCtrl color;
    private MenuCtrl menuCtrl;
    private Tutorial tutorial;
    private ItemGet item;
    private float currentVignetteValue = -1f;

    void Start()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        rb.gravityScale = 5.0f;

        vignette = GetComponent<VignetteCtrl>();
        color = GetComponent<ColorCtrl>();
        menuCtrl = GetComponent<MenuCtrl>();
        tutorial = GetComponent<Tutorial>();
        item = GetComponent<ItemGet>();
    }
    private void FixedUpdate()
    {
        if (menuCtrl.isMenuOpne) return;
        if(!tutorial.isTutorial) Move();
    }
    void Update()
    {
        if (menuCtrl.isMenuOpne) return;
        ChangeDirection();

        if (tutorial.isTutorial)
        {
            switch (tutorial.currentStep)
            {
                case 0:
                    if (Input.GetKeyDown(KeyCode.K))
                    {
                        Hold();
                    }
                    break;
                case 1:
                    Move();
                    break;
                case 2:
                    Move();
                    break;
                case 3:
                    rb.velocity = Vector2.zero;
                    animator.SetInteger("Speed", 0);
                    break;
            }
        }
        else
        {
            if (Input.GetKeyDown(KeyCode.Space) && !isJumping && !isHold)
            {
                rb.velocity += new Vector2(0, jumpForce);
                animator.SetBool("IsJump", true);
                isJumping = true;
                isGround = false;
            }

            if (Input.GetKeyDown(KeyCode.K))
            {
                Hold();
            }

            //Fall->Transition
            if (isJumping && rb.velocity.y < 0)
            {
                animator.SetBool("IsFalling", true);
            }

            if (isGround)
            {
                animator.SetBool("IsFalling", false);
            }
        }
        float curIntensity = nomalIntensity - (0.12f * item.itemCount);
        float target = isHold ? holdIntensity : curIntensity;

        if (!Mathf.Approximately(currentVignetteValue, target))
        {
            currentVignetteValue = target;
            vignette.FadeVignetteIntensity(target, duration);
        }
        speed = isHold ? 50f : 10f; 
    }

    void Move()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        Vector2 velocity = rb.velocity;
        rb.AddForce(new Vector2(0, -55f));
        if (horizontal != 0f)
        {
            isRight = (horizontal > 0) ? true : false;
            dir = isRight ? 1f : -1f;

            velocity.x = horizontal * speed;
            rb.velocity = velocity;

            int Horizontal = (int)Input.GetAxisRaw("Horizontal");
            animator.SetInteger("Speed", Mathf.Abs(Horizontal));
        }
        else
        {
            velocity.x = 0f;
            rb.velocity = velocity;
            animator.SetInteger("Speed", 0);
        }
        if (horizontal == 0 && isJumping)
        {
            rb.velocity = new Vector2(0, rb.velocity.y);
        }
       // rb.drag = isGround ? groundDrag : airDrag;
    }

    private void Hold()
    {
        if (holdObj == null)
        {
            hit = Physics2D.Raycast(rayPoint.position, transform.right, rayDistans);
            if (hit.collider != null && hit.collider.tag == "Anxiety")
            {
                isHold = true;
                holdObj = hit.collider.gameObject;
                animator.SetBool("IsHold", true);

                holdObj.GetComponent<Rigidbody2D>().isKinematic = true;
                holdObj.transform.position = holdPoint.position;
                holdObj.transform.SetParent(transform);
            }
        }
        else
        {
            isHold = false;
            animator.SetBool("IsHold", false);

            holdObj.GetComponent<Rigidbody2D>().isKinematic = false;
            holdObj.transform.SetParent(null);
            holdObj = null;
        }
    }
    void ChangeDirection()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        Vector2 scale = transform.localScale;
        if (horizontal > 0)
        {
            //Right
            scale.x = Mathf.Abs(scale.x);
        }
        else if (horizontal < 0)
        {
            //Left
            scale.x = -Mathf.Abs(scale.x);
        }
        transform.localScale = scale;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isJumping = false;
            isGround = true;
            animator.SetBool("IsFalling", false);
            animator.SetBool("IsJump", false);
        }
    }
}
