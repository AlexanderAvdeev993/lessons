
using UnityEngine;

public class Camera_Controller : MonoBehaviour
{
    public float mouseSensitiviti = 100f;
    public Transform Character;
    private float xRotation = 0f;
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    
    void Update()
    {
       float mouseX = Input.GetAxis("Mouse X") * mouseSensitiviti * Time.deltaTime;
       float mouseY = Input.GetAxis("Mouse Y") * mouseSensitiviti * Time.deltaTime;

       xRotation -= mouseY;
       xRotation = Mathf.Clamp(xRotation, -90f, 90f);

       transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
       Character.Rotate(Vector3.up * mouseX); 
    }
}
