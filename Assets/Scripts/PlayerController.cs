using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    
    [SerializeField] private float velocidad = 5f;
    [SerializeField] private float potenciaSalto = 7f;
    private Vector2 direccionMovimiento;
    private Rigidbody2D rb;
    private SpriteRenderer sprite;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();
    }

    public void OnMove (InputValue  value)
    {
        direccionMovimiento = value.Get<Vector2>();
    }
    public void OnJump (InputValue value)
    {
        if (value.isPressed)
        {
            rb.linearVelocity = new Vector2(rb.linearVelocityX, potenciaSalto);
        }
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //Para que se mueva el jugador
        rb.linearVelocity = new Vector2(direccionMovimiento.x*velocidad, rb.linearVelocity.y);

        //Girar Sprite
        if(direccionMovimiento.x > 0 && sprite.flipX)
        {
            sprite.flipX = false; //Derecha
        }
        else
        {
            if(direccionMovimiento.x < 0 && !sprite.flipX)
            {
                sprite.flipX = true; //Izquierda
            }
        }
    }
}
