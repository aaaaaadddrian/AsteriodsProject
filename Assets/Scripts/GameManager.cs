using UnityEngine;

public class GameManager : MonoBehaviour
{
    public Player player;
    public int lives = 3;
    public float respawnTime = 3.0f;

    public void playerDies()
    {
        this.lives--;
        if (this.lives <= 0)
        {
            gameOver();
        }
        Invoke(nameof(respawn), respawnTime );
    }

    private void respawn()
    {
        this.player.transform.position = Vector3.zero;
        this.player.gameObject.SetActive(true);
    }

    private void gameOver()
    {
        
    }
}
