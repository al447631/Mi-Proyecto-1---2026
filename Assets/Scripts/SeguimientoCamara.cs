using UnityEngine;

public class SeguimientoCamara : MonoBehaviour
{
    public Transform jugador; 
    public float suavidad = 5f; // Para que sea mas fluido
    
    
    public Vector3 compensacion = new Vector3(0f, 3f, -10f); 

    
    void LateUpdate()
    {
        if (jugador != null)
        {
            // Calculamos dónde debería estar la cámara
            Vector3 posicionObjetivo = jugador.position + compensacion;

            // Movemos la cámara suavemente desde donde está, hacia el objetivo
            transform.position = Vector3.Lerp(transform.position, posicionObjetivo, suavidad * Time.deltaTime);
        }
    }
}