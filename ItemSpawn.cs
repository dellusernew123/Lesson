using System.Collections.Generic;
using UnityEngine;

public class ItemSpawn : MonoBehaviour
{
    [SerializeField] private List<SpawnPoint> _spawnPoints;
    [SerializeField] private float _cooldown;
    [SerializeField] private List<Item> _itemsPrefab;

    private float _time;

    private void Update()
    {
        _time += Time.deltaTime;

        if (_time >= _cooldown)
        {
            SpawnItem();
        }


    }

    private void SpawnItem()
    {
        List<SpawnPoint> emptyPoints = GetEmptyPoints();

        if (emptyPoints.Count == 0)
        {
            _time = 0;
            return;
        }

        SpawnPoint spawnPoint = emptyPoints[Random.Range(0, emptyPoints.Count)];
        Item itemPrefab = _itemsPrefab[Random.Range(0, _itemsPrefab.Count)];

        Item item = Instantiate(itemPrefab, spawnPoint.Position, Quaternion.identity);

        spawnPoint.Occupy(item);

        _time = 0;
    }

    private List<SpawnPoint> GetEmptyPoints()
    {
        List<SpawnPoint> emptyPoints = new List<SpawnPoint>();

        foreach (SpawnPoint point in _spawnPoints)
            if (point.IsEmpty == true)
                emptyPoints.Add(point);

        return emptyPoints;
    }
}
