
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    public float sensitivity = 2f;
    public float upperLimit = 90f;
    public float lowerLimit = -90f;
    private float rotationX;
    private float rotationY;
    
    void Update()
    {
        if (Input.touchCount == 1)
        {
            Touch touch = Input.GetTouch(0);
            if (touch.phase == TouchPhase.Moved && touch.position.x > Screen.width / 2)
            {
            float deltaX = -touch.deltaPosition.y * sensitivity * Time.deltaTime;
            float deltaY = touch.deltaPosition.x * sensitivity * Time.deltaTime;

            rotationX -= deltaX;
            rotationX = Mathf.Clamp(rotationX, lowerLimit, upperLimit);
            rotationY -= deltaY;
            
            transform.localEulerAngles = new Vector3(rotationX, rotationY, 0f);
            }
        }
    }
}




  
 