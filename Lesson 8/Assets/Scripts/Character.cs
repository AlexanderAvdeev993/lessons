using System;
using UnityEngine;


public class Character : MonoBehaviour
{
   private Rigidbody2D rb;
   private Animator animator;

   private float horizontalMove = 0f;
   public float speed = 1f;
   public float jumpForce = 8f;
   public float checkGroundOffsetY = -1.8f;
   public float checkGroundRadius = 0.3f;

   private bool facingRight = true;
   private bool isGrounded = true;
   


   private void Start() 
   {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
   }

   private void Update() 
   {   
       Jump();
       Run();
      
   }

   private void Run()
   {
        horizontalMove = Input.GetAxisRaw("Horizontal") * speed;
        
        animator.SetFloat("HorizontalMove", Mathf.Abs(horizontalMove));
        

        if(horizontalMove < 0 && facingRight)
        {
            Flip();
        }
        else if(horizontalMove > 0 && !facingRight)
        {
            Flip();
        }

   }
   private void FixedUpdate()
   {
        Vector2 targetVelocity = new Vector2(horizontalMove * 10f, rb.velocity.y);
        rb.velocity = targetVelocity;

        CheckGround();
   }

   private void Flip()
    {
        facingRight = !facingRight;

        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }

    private void CheckGround()
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll
            (new Vector2(transform.position.x, transform.position.y + checkGroundOffsetY), checkGroundRadius);

        if(colliders.Length > 1)
        {
            isGrounded = true;
        }
        else
        { 
            isGrounded = false;
        }
    }
    private void Jump()
    {   
        if(isGrounded && Input.GetKeyDown(KeyCode.Space))
        {
            rb.AddForce(transform.up * jumpForce, ForceMode2D.Impulse);
        }
        
        if(isGrounded == false)
        {
            animator.SetBool("Jump", true);
        }
        else
        {
            animator.SetBool("Jump", false);
        }
    }
}
/*public class Character : MonoBehaviour
{
    public event Action<Vector3, float> OnMoving;

    [SerializeField] private float speed = 1f;

    private GameControls controller;
    private Animator animator;

    private Vector3 directionMove = new Vector3(0, 0, 0);

    private void Awake()
    {
        controller = new GameControls(); 
        controller.Enable();     
    }

    private void OnEnable()
    {
        
        controller.Controls.OnMoving.performed += Move;
        controller.Controls.OnMoving.canceled += StopMove;
    }
    private void OnDisable()
    {       
        controller.Controls.OnMoving.performed -= Move;
        controller.Controls.OnMoving.canceled -= StopMove;
        controller.Disable();
    }

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    private void Move(InputAction.CallbackContext obj)
    {
        directionMove.x = obj.ReadValue<float>();
        animator.SetBool("Run", true);
        AnimationDirection(directionMove.x);
    }
    private void StopMove(InputAction.CallbackContext obj)
    {
        directionMove.x = 0;
        animator.SetBool("Run", false);
    }

    private void Update()
    {
        OnMoving?.Invoke(directionMove, speed);
    }

    private void AnimationDirection(float direction)
    {
        if(direction > 0)
        {
            animator.transform.rotation = Quaternion.Euler(0, 0, 0);
        }
        else if(direction < 0)
        {
            animator.transform.rotation = Quaternion.Euler(0, 180, 0);
        }
    }
}*/
