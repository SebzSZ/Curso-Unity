using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private GameObject _enemy;
    [SerializeField] private float _spawnTime;
    private BoxCollider2D _boxCollider;
    private float _spawnTimer;

    private void Start()
    {
        _boxCollider = GetComponent<BoxCollider2D>();
        _spawnTimer = _spawnTime;
    }

    private void Update()
    {
        _spawnTimer -= Time.deltaTime;

        if (_spawnTimer <= 0)
        {
            SpawnEnemy();
            _spawnTimer = _spawnTime;
        }
    }

    private void SpawnEnemy()
    {
        Vector2 randomPosition = GetPosition();
        Instantiate(_enemy, randomPosition, Quaternion.identity);
    }

    private Vector2 GetPosition()
    {
        Bounds bounds = _boxCollider.bounds;

        float randomX = Random.Range(bounds.min.x, bounds.max.x);
        float randomY = Random.Range(bounds.min.y, bounds.max.y);

        return new Vector2(randomX, randomY);
    }
}