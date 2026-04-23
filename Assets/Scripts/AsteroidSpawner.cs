using UnityEngine;

public class AsteroidSpawner : MonoBehaviour
{
    public Asteroid asteroidPrefab;
    public float projectileVariance = 15.0f;
    public float spawnRate = 2.0f;
    public int spawnAmount = 2;
    public float spawnDist = 15.0f;
    private void Start()
    {
        InvokeRepeating(nameof(spawn), this.spawnRate, this.spawnRate );
    }

    private void spawn()
    {
        for (int i = 0; i < this.spawnAmount; i++)
        {
            Vector3 spawnDir = Random.insideUnitCircle.normalized * this.spawnDist;
            Vector3 spawnPoint = this.transform.position + spawnDir;
            
            float variance = Random.Range(-this.projectileVariance, this.projectileVariance);
            Quaternion rotation = Quaternion.AngleAxis(variance, Vector3.forward);
            Asteroid asteroid = Instantiate(asteroidPrefab, spawnPoint, rotation);
            asteroid.size = Random.Range(asteroid.minSize, asteroid.maxSize);
            asteroid.setTrajectory(rotation * -spawnDir);
        }
    }
    
}
