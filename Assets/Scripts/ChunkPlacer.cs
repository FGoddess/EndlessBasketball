using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChunkPlacer : MonoBehaviour
{
    [SerializeField] private Transform player;
    [SerializeField] private List<Chunk> _chunksToSpawn;
    [SerializeField] private List<Chunk> _spawnedChunks = new List<Chunk>();
    [SerializeField] private Chunk _firstChunk;
    void Start()
    {
        Chunk firstChunk = Instantiate(_firstChunk);
        _spawnedChunks.Add(firstChunk);
    }

    // Update is called once per frame
    void Update()
    {
        if (player.position.y + 10 > _spawnedChunks[_spawnedChunks.Count - 1].End.position.y)
            SpawnChunk();
    }

    public void SpawnChunk()
    {
        Chunk newChunk = Instantiate(_chunksToSpawn[Random.Range(0, _chunksToSpawn.Count)]);
        newChunk.transform.position = _spawnedChunks[_spawnedChunks.Count - 1].End.position - newChunk.Begin.localPosition;
        _spawnedChunks.Add(newChunk);
        if(_spawnedChunks.Count > 3)
        {
            Destroy(_spawnedChunks[0].gameObject);
            _spawnedChunks.RemoveAt(0);
        }
    }
}
