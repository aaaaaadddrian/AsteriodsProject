using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{

    public float thrustSpeed = 1.0f;
    public float turnSpeed = 1.0f;
    public Bullet bulletPrefab;
    
    private Rigidbody2D _rb;
    private bool _thrusting;
    private float _turnDirection;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        _thrusting = Keyboard.current.wKey.isPressed || Keyboard.current.upArrowKey.isPressed;

        if (Keyboard.current.aKey.isPressed || Keyboard.current.leftArrowKey.isPressed){
            _turnDirection = 1.0f;
        }else if ((Keyboard.current.dKey.isPressed || Keyboard.current.rightArrowKey.isPressed)){
            _turnDirection = -1.0f;
        } else{
            _turnDirection = 0.0f;
        }

        if (Keyboard.current.spaceKey.isPressed || Mouse.current.leftButton.isPressed)
        {
            Shoot();
        }
    }

    private void FixedUpdate()
    {
        if (_thrusting)
        {
            _rb.AddForce(this.transform.up * this.thrustSpeed);
        }

        if (_turnDirection != 0.0f)
        {
            _rb.AddTorque(_turnDirection * this.turnSpeed);
        }
    }

    private void Shoot()
    {
        Bullet bullet = Instantiate(this.bulletPrefab, this.transform.position, this.transform.rotation);
        bullet.project(this.transform.up);
    }

    private void oncollision(Collision2D collision)
    {
        if (collision.gameObject.tag == "Asteroid")
        {
            _rb.linearVelocity = Vector2.zero;
            _rb.angularVelocity = 0.0f;
            this.gameObject.SetActive(false);
            
            FindAnyObjectByType<GameManager>().playerDies();
        }
    }
    

}
