using System.Collections;
using UnityEngine;
using Random = UnityEngine.Random;

public class Spawner : MonoBehaviour
{
    [SerializeField] private Transform[] _spawnPoints;
    [SerializeField] private float _spawnInterval;
    [SerializeField] private Enemy _enemyPrefab;
    
    private float _timer;

    private void Start()
    {
        StartCoroutine(SpawnCoroutine());
    }

    private IEnumerator SpawnCoroutine()
    {
        while (true)
        {
            _timer += Time.deltaTime;
        
            if (_timer >= _spawnInterval)
            {
                Transform randomSpawnPoint = _spawnPoints[Random.Range(0, _spawnPoints.Length)];
                Enemy enemy = Instantiate(_enemyPrefab, randomSpawnPoint.position, Quaternion.identity);
                enemy.StartMoving(ChooseDirection());
            
                _timer-= _spawnInterval;
            }
            yield return null;
        }
    }
    
    private Vector2 ChooseDirection()
    {
        Vector2 randomDirection = Random.insideUnitCircle;
        return randomDirection;
    }
}
