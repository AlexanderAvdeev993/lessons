
using UnityEngine;

public class Enemy_Movement : MonoBehaviour

{
    [SerializeField] private float moveDistance = 5.0f; 
    [SerializeField] private GameObject deathAnimation;
    [SerializeField] private float speed = 1.0f;

    private Vector2 startPoint;
    private Vector2 endPoint;
    private bool isMovingForward = true;
    private bool facingRight = true;

    void Start()
    {   
        startPoint = transform.position;
        endPoint = startPoint + new Vector2(moveDistance, 0); 
           
    }

    void Update()
    {
        float step = speed * Time.deltaTime;
        if (isMovingForward)
        {
            transform.Translate(Vector2.right * step);
            if (transform.position.x >= endPoint.x)
            {
                isMovingForward = false;
                Flip();
            }
        }
        else
        {
            transform.Translate(Vector2.left * step);
            if (transform.position.x <= startPoint.x)
            {
                isMovingForward = true;
                Flip();
            }
        }
    }

    private void Flip()
    {
        facingRight = !facingRight;

        Vector2 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {   
        
        if (other.gameObject.CompareTag("Player") && other.gameObject.GetComponent<Rigidbody2D>().velocity.y < 0)
        {
            Death();     
        }
    }

    private void Death()
    {   
        deathAnimation = Instantiate(deathAnimation, transform.position, transform.rotation);

        Destroy(gameObject);

        Destroy(deathAnimation, 1.0f);      
    }
}
