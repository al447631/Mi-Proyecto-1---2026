using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float velocidad = 5f;
    [SerializeField] private float potenciaSalto = 7f;
    [SerializeField] private LayerMask capaSuelo; // Detectar suelo
    [SerializeField] private Transform controladorSuelo; 
    [SerializeField] private Vector2 dimensionesCaja = new Vector2(0.8f, 0.2f);
    
    private Vector2 direccionMovimiento;
    private Rigidbody2D rb;
    private SpriteRenderer sprite;
    public Animator anim;
    [SerializeField] private bool enSuelo;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
    }

    public void OnMove (InputValue value)
    {
        direccionMovimiento = value.Get<Vector2>();
    }
    
    public void OnJump (InputValue value)
    {
        if (value.isPressed && enSuelo)
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, potenciaSalto);
        }
    }

    void Start()
    {
        
    }

    void FixedUpdate()
    {
        // 1. Detectamos el suelo correctamente
        Collider2D objetoTocado = Physics2D.OverlapBox(controladorSuelo.position, dimensionesCaja, 0f, capaSuelo);

        if (objetoTocado != null)
        {
            enSuelo = true;
        }
        else
        {
            enSuelo = false;
        }

        

        // 2. Para que se mueva el jugador
        rb.linearVelocity = new Vector2(direccionMovimiento.x * velocidad, rb.linearVelocity.y);

        // 3. Girar Sprite
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

        anim.SetFloat("VelocidadX", Mathf.Abs(rb.linearVelocity.x));
        anim.SetBool("EnSuelo", enSuelo);
    }
}