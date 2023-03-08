
using UnityEngine;


public class Player_Controller : MonoBehaviour
{
   private Rigidbody2D rb;
   private Animator animator;
   [SerializeField] private GameObject deathAnimation;
   
   

   [SerializeField] private float horizontalMove = 0f;
   [SerializeField] private float speed = 1f;
   [SerializeField] private float jumpForce = 8f;
   [SerializeField] private float checkGroundOffsetY = -1.8f;
   [SerializeField] private float checkGroundRadius = 0.3f;

   private bool facingRight = true;
   private bool isGrounded = true;
   private Canvas canvas;
   


   private void Start() 
   {    
        canvas = FindObjectOfType<Canvas>();
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        canvas.enabled = false;
        
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

        Vector2 localScale = transform.localScale;
        localScale.x *= -1;
        transform.localScale = localScale;
    }

    private void CheckGround()
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll
            (new Vector2(transform.position.x, transform.position.y + checkGroundOffsetY), checkGroundRadius);

        isGrounded = colliders?.Length > 1;
        
    }
    private void Jump()
    {   
        if(isGrounded && Input.GetKeyDown(KeyCode.Space))
        {
            rb.AddForce(transform.up * jumpForce, ForceMode2D.Impulse);
        }
        
        bool isJumping = !isGrounded;
        animator.SetBool("Jump", isJumping);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {   
        
        if (other.gameObject.CompareTag("Enemy") && rb.velocity.y == 0)
        {
            Death();     
        }
        else if (other.gameObject.CompareTag("Trap"))
        {
            Death();     
        } 
    }
    private void Death()
    {   
        canvas.enabled = true;      

        deathAnimation = Instantiate(deathAnimation, transform.position, transform.rotation);

        Destroy(gameObject);

        Destroy(deathAnimation, 1.0f);        
    }
}

