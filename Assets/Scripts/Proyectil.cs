using UnityEngine;

public class Proyectil : MonoBehaviour
{

    public float velocidadProyectil = 10f;
    private Rigidbody2D rb;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>(); 
        rb.linearVelocity = transform.right * velocidadProyectil;

        Destroy(gameObject, 3f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
