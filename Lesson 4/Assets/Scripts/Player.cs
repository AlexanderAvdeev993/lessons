
using UnityEngine;


[RequireComponent(typeof(Rigidbody))]
public class Player : MonoBehaviour
{   
    [SerializeField] private float movementSpeed;
    [SerializeField] private float rotationSpeed;
    [SerializeField] private Transform ammoSpawner;
    public BaseAmmo ammo;
    private Rigidbody _rb;
    private GameObject _ammoFolder;
  
    void Start()
    {
        _rb = GetComponent<Rigidbody>();
        _ammoFolder = new GameObject
        {
            name = "Ammo"
        };
    }
   
    void Update()
    {
        if(!Input.GetMouseButtonDown(0))
        {
            return;
        }
        BaseAmmo weapon = Instantiate(ammo, ammoSpawner.position, ammoSpawner.rotation, _ammoFolder.transform);
        weapon.Launch(transform.forward);                           
    }

    private void FixedUpdate() 
    {
       float sideForce = Input.GetAxis("Horizontal") * rotationSpeed;

       if (sideForce != 0f)
       {
           _rb.angularVelocity = new Vector3(0f, sideForce, 0f);
       }

       float forwardForce = Input.GetAxis("Vertical") * movementSpeed;
       if (forwardForce != 0f)
       {
           _rb.velocity = _rb.transform.forward * forwardForce;
       }

       if(transform.position.y < -2f)
       {
           transform.position = Vector3.up;
       }
    }
}
