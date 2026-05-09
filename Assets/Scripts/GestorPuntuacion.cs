using UnityEngine;
using UnityEngine.UIElements;

public class GestorPuntuacion : MonoBehaviour
{

    public static GestorPuntuacion Instancia;
    public static int puntuacionGlobal = 0;
    private Label textoPuntuacion;
    
    [SerializeField] private UIDocument uiDocument;

    void Awake()
    {
        Instancia = this; 
    }

    void Start()
    {
        
        var root = uiDocument.rootVisualElement;
        textoPuntuacion = root.Q<Label>("TextoPuntuacion");
        
        ActualizarTexto();
    }

    
    public void SumarPuntos(int puntos)
    {
        puntuacionGlobal += puntos;
        ActualizarTexto();
    }

    private void ActualizarTexto()
    {
        if (textoPuntuacion != null)
        {
            textoPuntuacion.text = "Puntos: " + puntuacionGlobal;
        }
    }
}