using System.Collections.Generic;
using System.Linq;
using System;
using UnityEngine;

public class ChunksPlacer : MonoBehaviour
{
    public Transform Player;
    public Chunk[] ChunkPrefabs;
    public Chunk FirstChunk;

    private List<Chunk> spawnedChunks = new List<Chunk>();

    private void Start()
    {
        spawnedChunks.Add(FirstChunk);
    }

    private void Update()
    {
        if (Player.position.y > spawnedChunks[spawnedChunks.Count - 1].End.position.y - 15)
        {
            SpawnChunk();
        }
    }

    private int rand()
    {
        System.Random randd = new System.Random();

        int temp;

        temp = randd.Next(0, 2);

        return temp;
    }

    private void SpawnChunk()
    {
        Chunk newChunk = Instantiate(ChunkPrefabs[rand()]);
        newChunk.transform.position = spawnedChunks[spawnedChunks.Count - 1].End.position - newChunk.Begin.localPosition;
        spawnedChunks.Add(newChunk);

        if (spawnedChunks.Count >= 4)
        {
            Destroy(spawnedChunks[0].gameObject);
            spawnedChunks.RemoveAt(0);
        }
    }
}