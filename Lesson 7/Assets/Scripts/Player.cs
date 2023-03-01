
using UnityEngine;

public class Player : MonoBehaviour
{   
    CharacterController controller;
    Animator animator;
    public float movementSpeed = 2.0f;
    public float movementSprint = 4.0f;
    public float gravity = -9.81f;
    public float animationBlendSpeed = 0.2f;
    public float targetAnimationSpeed = 0.0f;
    

    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;
    bool isGrounded;
    bool isSprint;
    
           
    Vector3 move;
    Vector3 velocity;
     
    public CharacterController characterController; 
    public Animator CharacterAnimator
    {
        get { return animator = animator ?? GetComponent<Animator>(); }
    }

    
    void Update()
    {          
        Move();
        Gravity();
        
    }

    public void Move()
    {   
        float vertical = Input.GetAxis("Vertical");
        float horizontal = Input.GetAxis("Horizontal");
        
        isSprint = Input.GetKey(KeyCode.LeftShift);
        float currentSpeed = isSprint ? movementSprint : movementSpeed;
        if(move.sqrMagnitude > 0.0f)
        {
            targetAnimationSpeed = isSprint ? 1.0f : 0.5f;
        }
        else
        {
            targetAnimationSpeed = 0.0f;
        }
        
             
        move = transform.right * horizontal + transform.forward * vertical;
        if(Input.GetKey(KeyCode.LeftShift) && isGrounded == true)
        {
            characterController.Move(move * movementSprint * Time.deltaTime);
        }
        else
        {
            characterController.Move(move * movementSpeed * Time.deltaTime);
        }
        CharacterAnimator.SetFloat("Speed", Mathf.Lerp(CharacterAnimator.GetFloat("Speed"), targetAnimationSpeed, animationBlendSpeed));
    }
    public void Gravity()
    {
        velocity.y += gravity * Time.deltaTime;
        characterController.Move(velocity * Time.deltaTime); 

        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask); 
        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }  
    }  
}
