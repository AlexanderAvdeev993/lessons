
using UnityEngine;

public class Movement : MonoBehaviour
{
    public float speed = 10;
    private Rigidbody2D rb;
    public Animator animator;
    bool facingRight = true; 


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    
    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        
        if (horizontal > 0 && !facingRight || horizontal < 0 && facingRight)
        {
            Flip();
        }
        
        animator.SetFloat("Horizontal", horizontal);
        animator.SetFloat("Vertical", vertical);     
        animator.SetFloat("Speed", rb.velocity.sqrMagnitude);

        rb.velocity = new Vector2(horizontal, vertical);
    }

    private void Flip()
    {
        facingRight = !facingRight;

        Vector2 localScale = transform.localScale;
        localScale.x *= -1;
        transform.localScale = localScale;
    }
}
