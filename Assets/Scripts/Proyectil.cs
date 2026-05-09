using UnityEngine;

public class Proyectil : MonoBehaviour
{

    public float velocidadProyectil = 10f;
    private Rigidbody2D rb;
    private Animator anim;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>(); 
        rb.linearVelocity = transform.right * velocidadProyectil;

        
        anim = GetComponent<Animator>();
    }

    void OnTriggerEnter2D(Collider2D otro)
    {
        if (otro.CompareTag("Suelo"))
        {
            gameObject.tag = "Untagged";

            rb.linearVelocity = Vector2.zero; //
            rb.bodyType = RigidbodyType2D.Static;

            if (anim != null)
            {
                anim.enabled = false; // Esto congela el dibujo de inmediato
            }

            this.enabled = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
