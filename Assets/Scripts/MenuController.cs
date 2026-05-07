using UnityEngine;
using UnityEngine.UIElements; // Necesario para UI Toolkit
using UnityEngine.SceneManagement; // Necesario para cambiar de escenas

[RequireComponent(typeof(UIDocument))]
public class MainMenuController : MonoBehaviour
{
    [Tooltip("Nivel1")]
    public string sceneToLoad = "Nivel1"; 

    private UIDocument _uiDocument;
    private Button _startButton;
    private Button _quitButton;

    private void OnEnable()
    {
        // 1. Obtenemos la referencia al UIDocument de este objeto
        _uiDocument = GetComponent<UIDocument>();

        // 2. Buscamos el botón dentro del documento 
        _startButton = _uiDocument.rootVisualElement.Q<Button>("Inicio");
        _quitButton = _uiDocument.rootVisualElement.Q<Button>("Salir");

        // 3. Verificamos que el botón exista 
        if (_startButton != null)
        {
            _startButton.clicked += StartGame;
        }
        if (_quitButton != null)
        {
            _quitButton.clicked += QuitGame;
        }
       
    }
    // Esta es la función que se ejecutará cuando hagas clic en el botón
    private void StartGame()
    {
        Debug.Log("Cargando la escena: " + sceneToLoad);
        SceneManager.LoadScene(sceneToLoad);
    }
    private void QuitGame()
    {
        Debug.Log("Saliendo del juego...");
        
        // Esta línea cierra el juego cuando ya está compilado (el .exe final)
        Application.Quit(); 

        // Este bloque de código hace que el botón también detenga el modo "Play" dentro del editor de Unity
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
    }


}