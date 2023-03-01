
using System.Collections.Generic;
using UnityEngine;

public class Stairs_Spawn : MonoBehaviour
{
    
    public Transform Player;
    public Chunk ChunkPrefab;
    private List<Chunk> spawnedChunks = new List<Chunk>();
    public Chunk FirstChunk;
    

    public float spawnDistanceUp = 5.0f;
    public float spawnDistanceDown = 5.0f;

    private void Start()
    {
        spawnedChunks.Add(FirstChunk);
    }

    private void SpawnChunkUp()
    {
        Chunk newChunk = Instantiate(ChunkPrefab);
        newChunk.transform.position = spawnedChunks[spawnedChunks.Count-1].End.position - newChunk.Begin.localPosition;
        spawnedChunks.Add(newChunk);
        

        if(spawnedChunks.Count >= 3)
        {
            Destroy(spawnedChunks[0].gameObject);
            spawnedChunks.RemoveAt(0);        
        } 
    }

    private void SpawnChunkDown()
    {
        Chunk newChunk = Instantiate(ChunkPrefab);
        newChunk.transform.position = spawnedChunks[spawnedChunks.Count-1].Begin.position - newChunk.End.localPosition;
        spawnedChunks.Add(newChunk);

        if(spawnedChunks.Count >= 3)
        {
            Destroy(spawnedChunks[0].gameObject);
            spawnedChunks.RemoveAt(0);
        }
    }

    private void Update() 
    {
        if(Player.position.y > spawnedChunks[spawnedChunks.Count - 1].End.position.y - spawnDistanceUp)
        {
            SpawnChunkUp();      
        }

        if(Player.position.y < spawnedChunks[spawnedChunks.Count - 1].Begin.position.y + spawnDistanceDown)
        {
            SpawnChunkDown();
        }
    }
}

