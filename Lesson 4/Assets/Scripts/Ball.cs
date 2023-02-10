
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]

public class Ball : BaseAmmo
{    
    [SerializeField] public float launchSpeed;

    private Rigidbody _rb;

    private void Awake() 
    {
        _rb = GetComponent<Rigidbody>();
    }

    public override void Launch(Vector3 direction)
    {
        _rb.AddForce(direction * launchSpeed, ForceMode.Impulse);

        Destroy(gameObject, 5f);
    }   
}
