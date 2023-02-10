
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Grenade : BaseAmmo
{   
    [SerializeField] public float launchSpeed;
    [SerializeField] private float delay;
    [SerializeField] private float explosionForce;
    [SerializeField] private float radius;
    [SerializeField] private float modifiedAngle;
    private Rigidbody _rb;
    ParticleSystem particle;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody>();
        particle = GetComponentInChildren<ParticleSystem>();
        particle.Stop();

    }
    
    public override void Launch(Vector3 direction)
    {
         direction.y = Quaternion.AngleAxis(modifiedAngle, Vector3.up).y;

         _rb.AddForce(direction * launchSpeed, ForceMode.Impulse);
    }

    private void OnCollisionEnter() 
    {
        Explode();
       
        particle.Play();
               
        Destroy(gameObject, delay);
    }

    private void Explode()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, radius);
        foreach (Collider collider in colliders)
        {
            Rigidbody rigidbody = collider.attachedRigidbody;
            if(rigidbody)
            {
                rigidbody.AddExplosionForce(explosionForce, transform.position, radius);
            }
        }
    }
    
}
