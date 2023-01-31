
using UnityEngine;

public class Rotator : MonoBehaviour
{   
    [SerializeField] private float rotationSpeed = 50f;
    [SerializeField] private Vector3 rotationDirection = new Vector3( 1, 1, 1);
       
    void Update()
    {
        transform.rotation *= Quaternion.AngleAxis(rotationSpeed * Time.deltaTime, rotationDirection);
    }   
}
