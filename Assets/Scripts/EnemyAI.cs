using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    [SerializeField] private float _enemyYSpeed;

    [SerializeField] private GameObject _enemyBullet;
    private float _minTime = 0.5f;
    private float _maxTime = 1.5f;
    private float _shootTimer;

    private void Start()
    {
        _shootTimer = Random.Range(_minTime, _maxTime);
    }

    private void Update()
    {
        transform.Translate(Vector3.down * _enemyYSpeed *  Time.deltaTime);

        Shoot();
    }

    private void Shoot()
    {
        _shootTimer -= Time.deltaTime;

        if (_shootTimer <= 0)
        {
            Instantiate(_enemyBullet, transform.position, transform.rotation);
            _shootTimer = Random.Range(_minTime, _maxTime);
        }
    }
}