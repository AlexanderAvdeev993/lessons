
using UnityEngine;

public class AmmoArea : MonoBehaviour
{
    [SerializeField] private BaseAmmo ammoPrefab;
    
    private void OnTriggerEnter(Collider other)
    {
        var player = other.GetComponentInParent<Player>();
        if(!player)
        {
            return;
        }
        player.ammo = ammoPrefab;

        Debug.Log($"Rearmed by {player.ammo.GetComponent<BaseAmmo>()}");
    }

}
