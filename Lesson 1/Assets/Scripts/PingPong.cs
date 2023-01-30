
using UnityEngine;

public class PingPong : MonoBehaviour
{      
    public float speed = 10f;
    private bool moveRight = true;


    void Update()
    {
        if(moveRight)
        {
            transform.position = new Vector3(transform.position.x + speed * Time.deltaTime, transform.position.y, transform.position.z);
            if (transform.position.x >= 7)
            {
                moveRight = false;
            }
        }
        else
        {
            transform.position = new Vector3(transform.position.x - speed * Time.deltaTime, transform.position.y, transform.position.z);
            if (transform.position.x <= -7)
            {
                moveRight = true;
            }
        }
    }               
}
