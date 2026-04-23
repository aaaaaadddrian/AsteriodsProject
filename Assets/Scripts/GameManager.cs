using UnityEngine;

public class GameManager : MonoBehaviour
{
    public Player player;
    public int lives = 3;
    public float respawnTime = 3.0f;
    public ParticleSystem explosion;
    public int score = 0;

    public void playerDies()
    {
        this.explosion.transform.position = this.player.transform.position;
        this.explosion.Play();
        this.lives--;
        
        if (this.lives <= 0)
        {
            gameOver();
        }
        else
        {
            Invoke(nameof(respawn), respawnTime );
        }
       
    }

    public void asteroidDestroyed(Asteroid asteroid)
    {
        this.explosion.transform.position = asteroid.transform.position;
        this.explosion.Play(); 
    }

    private void respawn()
    {
        this.player.transform.position = Vector3.zero;
        this.player.gameObject.SetActive(true);
        
        this.player.gameObject.layer = LayerMask.NameToLayer("IgnoreCollisions");
        Invoke(nameof(turnOnCollisions), 3.0f);
    }

    private void turnOnCollisions()
    {
        this.player.gameObject.layer = LayerMask.NameToLayer("Player");
    }

    private void gameOver()
    {
        
    }
}
