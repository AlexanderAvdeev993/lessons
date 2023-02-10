
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Missile : BaseAmmo
{
    [SerializeField] public float launchSpeed;
    private Rigidbody _rb;

    private void Awake() 
    {
       _rb = GetComponent<Rigidbody>(); 
    }

    public override void Launch(Vector3 direction)
    {
        _rb.velocity = direction * launchSpeed;

        Destroy(gameObject, 5f);
    }
    
    private void OnCollisionEnter(Collision collision) 
    {
        Destroy(gameObject);        
    }
}
