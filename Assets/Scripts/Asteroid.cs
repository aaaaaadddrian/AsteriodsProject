using System;
using UnityEngine;
using Random = UnityEngine.Random;

public class Asteroid : MonoBehaviour
{
    public Sprite[] sprites;
    public float size = 1.0f;
    public float maxSize = 1.5f;
    public float minSize = 0.5f;
    public float speed = 5.0f;
    public float maxLifetime = 30.0f;
    
    private SpriteRenderer spriteRenderer;
    private Rigidbody2D rigidbody2D;
    

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        rigidbody2D = GetComponent<Rigidbody2D>();
    }
    private void Start()
    {
        spriteRenderer.sprite = sprites[Random.Range(0, sprites.Length)];
        this.transform.eulerAngles = new Vector3(0, 0, Random.Range(0, 361));
        this.transform.localScale = Vector2.one * this.size;
        rigidbody2D.mass = this.size;
    }

    public void setTrajectory(Vector2 trajectory)
    {
        rigidbody2D.AddForce(trajectory * this.speed);
        
        Destroy(this.gameObject, this.maxLifetime);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Bullet")
        {
            if ((this.size * 0.5f) >= this.minSize)
            {
                createSplit();
                createSplit();
            }
            FindAnyObjectByType<GameManager>().asteroidDestroyed(this);
            Destroy(this.gameObject);
        }
    }

    private void createSplit()
    {
        Vector2 position = this.transform.position;
        position += Random.insideUnitCircle * 0.5f;
        
        Asteroid half = Instantiate(this, position, this.transform.rotation );
        half.size = this.size * 0.5f;
        half.setTrajectory(Random.insideUnitCircle.normalized * this.speed);
    }
}
