
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject playerPrefab; 
    public GameObject enemyPrefab;
    public Transform playerSpawnPoint; 
    public Transform[] enemySpawnPoints; 

    void Start()
    {
        PlayerSpawn();

        foreach (Transform spawnPoint in enemySpawnPoints)
        {
            Instantiate(enemyPrefab, spawnPoint.position, spawnPoint.rotation);
        }
    }

    public void PlayerSpawn()
    {
        Instantiate(playerPrefab, playerSpawnPoint.position, playerSpawnPoint.rotation);
    } 
}
