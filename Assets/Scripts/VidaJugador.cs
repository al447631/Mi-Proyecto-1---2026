using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.InputSystem;
using Unity.VectorGraphics;
using UnityEngine.SceneManagement;

public class VidaJugador : MonoBehaviour
{
    public int vidaMaxima = 100;
    private int vidaActual;
    [SerializeField] private UIDocument uiDocument;
    private VisualElement barraRoja;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        vidaActual = vidaMaxima;

        var root = uiDocument.rootVisualElement;
        barraRoja = root.Q<VisualElement>("RellenoBarra");
    }

    // Update is called once per frame
    void Update()
    {
        
        if (Keyboard.current != null && Keyboard.current.pKey.wasPressedThisFrame)
        {
            RecibirDano(10);
        }
    }

    public void RecibirDano(int cantidadDano)
    {
        vidaActual -= cantidadDano;

        // Evitamos que la vida baje de cero
        if (vidaActual < 0) 
        {
            vidaActual = 0;
        }

        ActualizarBarra();

        if (vidaActual == 0 || vidaActual <= 0 )
        {
            Debug.Log("¡Has Muerto!"); 

            GestorPuntuacion.puntuacionGlobal = 0;

            SceneManager.LoadScene("GameOver");
        }
    }

    private void ActualizarBarra()
    {
        if (barraRoja != null)
        {
            // Porcentaje de Vida Restante
            float porcentaje = ((float)vidaActual / vidaMaxima) * 100f;  
            barraRoja.style.width = Length.Percent(porcentaje);
        }
    }
}
