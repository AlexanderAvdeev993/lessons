
using UnityEngine;

public class Spawn_Monster : MonoBehaviour
{
    public GameObject monsterPrefab;
    public float spawnDistance = 5.0f;
    public float respawnDelay = 1.0f;
    public float destroyDelay = 1.0f;

    private Transform playerTransform;
    private float lastSpawnTime;
   

    void Start()
    {
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void Update()
    {
        if (Time.time > lastSpawnTime + respawnDelay)
        {   
            
            Vector3 spawnPosition = playerTransform.position + playerTransform.forward * Random.Range(1, spawnDistance);
            
            
            RaycastHit hit;
            if (Physics.Raycast(playerTransform.position, spawnPosition - playerTransform.position, out hit, spawnDistance))
            {
                if (hit.collider.gameObject.layer == LayerMask.NameToLayer("Wall"))
                {
                    return; 
                }
            }

            GameObject monster = Instantiate(monsterPrefab, spawnPosition, Quaternion.identity);
            lastSpawnTime = Time.time;

            Destroy(monster, destroyDelay);
            Invoke("TurnOffLamp", 0.1f);
        }
    }
        
}

