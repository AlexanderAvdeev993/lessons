
using UnityEngine;

public class Player : MonoBehaviour
{   
    CharacterController controller;
    Camera characterCamera;
    Animator animator;
    public float movementSpeed = 2.0f;
    public float rotationSpeed = 0.2f;
    public float sprintSpeed = 5.0f;
    public float animationBlendSpeed = 0.2f;
    float rotationAngle = 0.0f;  
    float targetAnimationSpeed = 0.0f;
    public float jumpSpeed = 17.0f;
    bool isSprint = false;
    float speedY = 0.0f;
    float gravity = -9.81f;
    bool isJumping = false;
    bool isMoving = false;
    bool isAttacking = false;
     
    public CharacterController Controller
    {
        get { return controller = controller ?? GetComponent<CharacterController>(); }        
    }
    public Camera CharacterCamera
    {
        get { return characterCamera = characterCamera ?? FindObjectOfType<Camera>(); }
    }
    public Animator CharacterAnimator
    {
        get { return animator = animator ?? GetComponent<Animator>(); }
    }


    
    private void Start() 
    {               
        CharacterAnimator.SetTrigger("Spawn");
        Invoke("DoMoving", 2.0f);      
    } 

    void DoMoving()
    {
        isMoving = true;
    }

    void Death()
    {
        CharacterAnimator.SetTrigger("Death");
        isMoving = false;          
    }
    void ResetAttack()
    {
        isAttacking = false;
        animator.SetInteger("Attack_Int", 0);
    }

    void Update()
    {   
        if(isMoving)
        {            
            float vertical = Input.GetAxis("Vertical");
            float horizontal = Input.GetAxis("Horizontal");

            if(Input.GetButtonDown("Fire1"))
            {   
                isAttacking = true;
                int choose = Random.Range(1, 5);
                animator.SetInteger("Attack_Int", choose);
                Invoke("ResetAttack", 1f);
            }           

            if (Input.GetButtonDown("Jump") && !isJumping)
            {
                isJumping = true;
                CharacterAnimator.SetTrigger("Jump");
                speedY += jumpSpeed;
            }
            if (!Controller.isGrounded)
            {
                speedY += gravity * Time.deltaTime;
            }
            else if (speedY < 0.0f)
            {
                speedY = 0.0f;
            }
            CharacterAnimator.SetFloat("SpeedY", speedY / jumpSpeed);
            if(isJumping && speedY < 0.0f)
            {
                RaycastHit hit;
                if(Physics.Raycast(transform.position, Vector3.down, out hit, 1f, LayerMask.GetMask("Default")))
                {
                    isJumping = false;
                    CharacterAnimator.SetTrigger("Land");
                }
            }
        
            isSprint = Input.GetKey(KeyCode.LeftShift);
            Vector3 movement = new Vector3(horizontal, 0.0f, vertical);
            Vector3 rotatedMovement = Quaternion.Euler(0.0f, CharacterCamera.transform.rotation.eulerAngles.y, 0.0f) * movement.normalized;
            Vector3 verticalMovement = Vector3.up * speedY;

            float currentSpeed = isSprint ? sprintSpeed : movementSpeed;
            Controller.Move ((verticalMovement + rotatedMovement * currentSpeed) * Time.deltaTime);

            if(rotatedMovement.sqrMagnitude > 0.0f)
            {
                rotationAngle = Mathf.Atan2(rotatedMovement.x, rotatedMovement.z) * Mathf.Rad2Deg;
                targetAnimationSpeed = isSprint ? 1.0f : 0.5f;
            }
            else
            {          
                targetAnimationSpeed = 0.0f;                  
            }
            CharacterAnimator.SetFloat("Speed", Mathf.Lerp(CharacterAnimator.GetFloat("Speed"), targetAnimationSpeed, animationBlendSpeed));
            Quaternion currentRotation = Controller.transform.rotation;
            Quaternion targetRotation = Quaternion.Euler(0.0f, rotationAngle, 0.0f);
            Controller.transform.rotation = Quaternion.Lerp(currentRotation, targetRotation, rotationSpeed);
                
        }
        if(Input.GetKeyDown(KeyCode.Tab) && isMoving)
        {
            Death();             
        }
        else if(!isMoving)
        {
            Vector3 moveDirection = new Vector3(0, -5f, 0);
            Controller.Move(moveDirection * Time.deltaTime);           
        }       
    }
}
