using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public Player player;
    public int lives = 3;
    public float respawnTime = 3.0f;
    public ParticleSystem explosion;
    public int score = 0;
    public TextMeshProUGUI scoreText;
    
    
    //a main menu would be nice wouldnt it, add a ui adrian hrng
    
    public void playerDies()
    {
        this.explosion.transform.position = this.player.transform.position;
        this.explosion.Play();
        this.lives--;
        
        if (this.lives <= 0)
        {
            gameOver();
        }else
        {
            Invoke(nameof(respawn), respawnTime);
        }
       
    }
    //my many lives keep living and not not living like they should

    public void asteroidDestroyed(Asteroid asteroid)
    {
        this.explosion.transform.position = asteroid.transform.position;
        this.explosion.Play(); 
        
        score += asteroid.score;
        scoreText.text = "Score: " + score;
    }
    
    // why is death escaping me
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
       this.lives = 3;
       this.score = 0;
       
       Invoke(nameof(respawn), respawnTime);
    }
}
