
using UnityEngine;

public class Rotator : MonoBehaviour
{   
    public float rotationSpeed = 50f;
    public Vector3 rotationDirection = new Vector3( 1, 1, 1);
       
    void Update()
    {
        transform.rotation *= Quaternion.AngleAxis(rotationSpeed * Time.deltaTime, rotationDirection);
    }   
}
