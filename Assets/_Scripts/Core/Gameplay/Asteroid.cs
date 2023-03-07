using UnityEngine;

public class Asteroid : MonoBehaviour
{
    [SerializeField] private AsteroidDataSO _asteroidData;

    private Vector2 _moveDirection;
    private bool _isSubAsteroid;

    private AsteroidDataSO Data => _asteroidData;

    public void Init(Vector2 moveDirection, bool isSubAsteroid)
    {
        moveDirection.Normalize();
        _moveDirection = moveDirection;
        _isSubAsteroid = isSubAsteroid;
    }

    private void Update()
    {
        Move();
    }

    private void Move()
    {
        transform.Translate(Data.MovementData.MoveSpeed * Time.deltaTime * _moveDirection, Space.World);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Die();
    }

    private void Die()
    {
        if (_isSubAsteroid == false)
            SpawnSubAsteroids();

        Destroy(gameObject);
    }

    private void SpawnSubAsteroids()
    {
        for (int i = 0; i < Data.SubAsteroidsCount; i++)
        {
            var direction = new Vector2(Random.onUnitSphere.x, Random.onUnitSphere.y).normalized;
            var asteroid = Instantiate(Data.SubAsteroidPrefab, transform.position, Quaternion.identity);
            asteroid.Init(direction, true);
        }
    }
}