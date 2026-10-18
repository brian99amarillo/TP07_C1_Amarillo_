using UnityEngine;
using UnityEngine.UI;

public class UIMenuPause : MonoBehaviour
{

    [Header("Menu Pause Buttons")]
    [SerializeField] private Button btnContinue;      // Boton de continuar para volver al juego desde el menu de pausa
    [SerializeField] private Button btnSettings;    // Boton de opciones para abrir el panel de opciones desde el menu de pausa
    [SerializeField] private Button btnCredits;    // Boton de creditos para abrir el panel de creditos desde el menu de pausa
    [SerializeField] private Button btnExit;        // Boton de salir del juego desde el menu de pausa

    [Header("Panels & Scenes")]
    [SerializeField] private GameObject Pause;
    [SerializeField] private GameObject SettingsPanel;
    [SerializeField] private GameObject CreditsPanel;
    [SerializeField] private GameObject Game;
    private bool isPause = false;
    public bool IsPause { get { return isPause; } }

    private void Awake()  // Inicializacion de los botones y sliders
    {
        // Botones de pausa
        btnContinue.onClick.AddListener(OnContinueButtonClicked);
        btnSettings.onClick.AddListener(OnSettingsButtonClicked);
        btnCredits.onClick.AddListener(OnCreditsButtonClicked);
        btnExit.onClick.AddListener(OnExitButtonClicked);

#if UNITY_WEBGL && !UNITY_EDITOR
    btnExit.gameObject.SetActive(false);
#endif
    }

    private void Start()
    {
        Pause.SetActive(false);
    }

    private void Update()
    {
        if ((Input.GetKeyDown(KeyCode.Escape)) || Input.GetKeyDown(KeyCode.P))  // Pausa el juego al presionar la tecla Escape o P, y abre el menu de pausa
        {   
            isPause=!isPause;

            if (isPause)
            {
                PauseActived(); 
            }
            else
            {
                Restart();
            }
        }
    }
    private void PauseActived()                           // Pausa el juego y abre el menu de pausa
    {
        Game.SetActive(false);
        Pause.SetActive(true);
        Time.timeScale = 0f; // Detiene el tiempo
    }

    private void Restart()                         // Reanuda el juego y cierra el menu de pausa
    {
        if (SettingsPanel.activeInHierarchy || CreditsPanel.activeInHierarchy)
        {
            SettingsPanel.SetActive(false);
            CreditsPanel.SetActive(false);
        }
        Pause.SetActive(false);
        Game.SetActive(true);
        Time.timeScale = 1f; // Reanuda el tiempo
    }
    private void OnDestroy() // Remueve los listeners inicializados en el Awake 
    {
        // Botones del menu de pausa
        btnContinue.onClick.RemoveListener(OnContinueButtonClicked);
        btnSettings.onClick.RemoveListener(OnSettingsButtonClicked);
        btnCredits.onClick.RemoveListener(OnCreditsButtonClicked);
        btnExit.onClick.RemoveListener(OnExitButtonClicked);
    }

    public void ReturnToPauseMenu()
    {
        isPause = true;
        SettingsPanel.SetActive(false);
        CreditsPanel.SetActive(false);
        Pause.SetActive(true);
    }

    //Botones del menu de Pausa
    private void OnContinueButtonClicked()  // Boton de play para reanudar el juego
    {
        isPause = false;
        Restart();
    }
    private void OnSettingsButtonClicked() // Abre el panel de opciones desde el menu de pausa
    {
        Pause.SetActive(false);
        SettingsPanel.SetActive(true);

    }
    private void OnCreditsButtonClicked() // Abre el panel de los creditos desde el menu de pausa
    {
        Pause.SetActive(false);
        CreditsPanel.SetActive(true);
    }
    private void OnExitButtonClicked() // Metodo para salir del juego
    {
        Application.Quit();
#if UNITY_EDITOR
        // Dentro del editor: detiene el Play
        UnityEditor.EditorApplication.isPlaying = false;
#endif
    }

}