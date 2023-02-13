
using UnityEngine;
using UnityEngine.UI;

public class Character : MonoBehaviour
{   
    public float gravity = -9.81f;
    public float speed = 10.0f;
    public float jumpForce = 10.0f;
    public Joystick joystick; 
    public Button jumpButton;
    CharacterController controller;
    public CharacterController Controller { get {return controller = controller ?? GetComponent<CharacterController>(); } }

   
    private void Start() 
    {
        jumpButton.onClick.AddListener(Jump);
    }

    void Update()
    {   
        float vertical = joystick.Vertical;
        float horizontal = joystick.Horizontal;
              
        Vector3 movement = new Vector3(horizontal * speed, gravity, vertical * speed );
         
        Controller.Move(transform.TransformDirection(movement) * Time.deltaTime);           
    }

    void Jump()
    {   
        if(Controller.isGrounded)
        {
            Vector3 movement = new Vector3(0.0f, Mathf.Sqrt(jumpForce * -2f * gravity), 0.0f);
            Controller.Move(transform.TransformDirection(movement) * Time.deltaTime);
        } 
    }
}
