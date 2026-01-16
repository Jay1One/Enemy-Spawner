using UnityEngine;
using Random = UnityEngine.Random;

public class Spawner : MonoBehaviour
{
    [SerializeField] private Transform[] _spawnPoints;
    [SerializeField] private float _spawnInterval;
    [SerializeField] private Enemy enemyPrefab;
    
    private float _timer;

    private void Update()
    {
        _timer += Time.deltaTime;
        
        if (_timer >= _spawnInterval)
        {
            Transform randomSpawnPoint = _spawnPoints[Random.Range(0, _spawnPoints.Length)];
            Enemy enemy = Instantiate(enemyPrefab, randomSpawnPoint.position, Quaternion.identity);
            enemy.StartMoving(ChooseDirection());
            
            _timer-= _spawnInterval;
        }
    }

    private Vector2 ChooseDirection()
    {
        Vector2 randomDirection = Random.insideUnitCircle;
        return randomDirection;
    }
}
