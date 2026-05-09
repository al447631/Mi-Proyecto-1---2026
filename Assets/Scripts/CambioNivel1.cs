using UnityEngine;
using UnityEngine.SceneManagement; 

public class CambioNivel : MonoBehaviour
{
    [Header("Escribe el nombre EXACTO de tu siguiente nivel")]
    public string nombreSiguienteNivel; 

    void OnTriggerEnter2D(Collider2D otro)
    {
        
        if (otro.CompareTag("Player"))
        {
            Debug.Log("¡Pasando al nivel: " + nombreSiguienteNivel + "!");
            
            // Cargamos la nueva escena
            SceneManager.LoadScene(nombreSiguienteNivel);
        }
    }
}