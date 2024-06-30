using TMPro;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private AudioManager BGSound;
    [SerializeField] private UIManager Uimanage;
    public AstroiedManager settings;
    public Score score;

    private float spawnRateModifier = 1f;

    private float spawnTimer = 0f;
    private float baseSpawnRate = 0.1f;
    private GameObject asteroid;

    private void Update()
    {
        spawnTimer += Time.deltaTime;
        if (spawnTimer > baseSpawnRate / spawnRateModifier)
        {
            if (ShouldSpawnEnemy())
            {
                SpawnAsteroid();
                spawnTimer = 0f;
            }
        }
    }
    private bool ShouldSpawnEnemy()
    {
        if (score.Value >= 20)
        {
            StartCoroutine(Uimanage.WavePass());
            baseSpawnRate = 0.8f;
            spawnRateModifier = 1f;
            BGSound.Play("Theme 2");
            Debug.Log("Theme 2");
        }
        else
        {
            baseSpawnRate = 1f;
            spawnRateModifier = 1.5f;
            BGSound.Play("Theme 1");
            Debug.Log("Theme 1");
        }

        return true;
    }

    private void SpawnAsteroid()
    {
        float randomX = Random.Range(0, Screen.width);
        Vector3 randomScreenPosition = new Vector3(randomX, Screen.height, 10);
        Vector3 spawnPosition = Camera.main.ScreenToWorldPoint(randomScreenPosition);

        if (score.Value >= 20)
        {
            asteroid = Instantiate(settings.enemyPrefab[1], spawnPosition, Quaternion.identity);
        }
        else
        {
            asteroid = Instantiate(settings.enemyPrefab[0], spawnPosition, Quaternion.identity);
        }

        if (asteroid.TryGetComponent<Rigidbody2D>(out var rb))
        {
            Vector3 randomDirection = Vector3.down + Random.insideUnitSphere * 0.1f;
            float randomForceMagnitude = Random.Range(settings.AsteroidData.minForce, settings.AsteroidData.maxForce);
            Vector3 randomForce = randomDirection * randomForceMagnitude;
            rb.AddForce(randomForce);
        }
    }

}