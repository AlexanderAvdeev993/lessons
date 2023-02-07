
using UnityEngine;

public class TachRotator : MonoBehaviour
{
   
    [SerializeField] private float rotateSpeed = 1.0f;

    private void Update()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            Vector2 touchDeltaPosition = touch.deltaPosition;
            transform.Rotate(0, -touchDeltaPosition.x * rotateSpeed, 0);
        }
    }
}

