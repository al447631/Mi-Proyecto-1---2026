using UnityEngine;

public class Enemigo : MonoBehaviour
{

    public int vida = 30;
    public float velocidad = 3f;
    public bool esVolador = false; // Diferemciar Enemigo Volador

    private Transform jugador; //Saber donde esta el PJ
    private SpriteRenderer spriteR;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // Seguimiento del enemigo hacia elPJ
        GameObject objetoJugador = GameObject.FindGameObjectWithTag("Player");
        if (objetoJugador != null)
        {
            jugador = objetoJugador.transform;
        }
        
        spriteR = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (jugador != null)
        {
            if (esVolador)
            {
                // Enemigo Volador (EJE x e y)
                transform.position = Vector2.MoveTowards(transform.position, jugador.position, velocidad * Time.deltaTime);
            }
            else
            {
                // Enemigo Suelo (EJE X)
                Vector2 objetivoSuelo = new Vector2(jugador.position.x, transform.position.y);
                transform.position = Vector2.MoveTowards(transform.position, objetivoSuelo, velocidad * Time.deltaTime);
            }

            // Girar Sprite
            spriteR.flipX = jugador.position.x > transform.position.x;
        }
    }

    // Detectar Choque con  PJ/Proyectil
    void OnTriggerEnter2D(Collider2D otro)
    {
        // 1. Proyectil
        if (otro.CompareTag("Arma")) 
        {
            vida -= 10; // 
            Destroy(otro.gameObject); 

            if (vida <= 0)
            {
                Destroy(gameObject); // 
            }
        }
        // 2. Pj
        else if (otro.CompareTag("Player"))
        {
            
            VidaJugador vidaJugador = otro.GetComponent<VidaJugador>();
            if (vidaJugador != null)
            {
                vidaJugador.RecibirDano(10);
            }
        }
    }
}
