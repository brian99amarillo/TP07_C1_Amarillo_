using UnityEngine;
using UnityEngine.UI;

public class UIMenuPause : MonoBehaviour
{

    [Header("Menu Pause Buttons")]
    [SerializeField] private Button btnContinue;      
    [SerializeField] private Button btnSettings;    
    [SerializeField] private Button btnCreditts;    
    [SerializeField] private Button btnExit;       

    [Header("Panels & Scenes")]
    [SerializeField] private GameObject pause;
    [SerializeField] private GameObject settingsPanel;
    [SerializeField] private GameObject credittsPanel;
    [SerializeField] private GameObject game;
    [SerializeField] private GameObject background;
    [SerializeField] private AudioManager controllerMusic;
    private bool isPause = false;
    private void Awake()
    {   // Botones del menu principal
        btnContinue.onClick.AddListener(OnContinueButtonClicked);
        btnSettings.onClick.AddListener(OnSettingsButtonClicked);
        btnCreditts.onClick.AddListener(OnCredittsButtonClicked);
        btnExit.onClick.AddListener(OnExitButtonClicked);
    }

    private void Start()
    {
        pause.SetActive(false);
    }

    private void Update()
    {
        if ((Input.GetKeyDown(KeyCode.Escape)) || Input.GetKeyDown(KeyCode.P))  // Pausa el juego al presionar la tecla Escape o P, y abre el menu de pausa
        {
            if (isPause){Reanudar();} else { Pausar();}
        }
    }
    private void Pausar()
    {
        isPause = true;
        //AudioManager.Instance.PauseMusicGameplay();
        //controllerMusic.ActiveMusicMenuPause();
        game.SetActive(false);
        background.SetActive(false);
        pause.SetActive(true);
        Time.timeScale = 0f; // Detiene el tiempo
    }

    private void Reanudar()
    {
        isPause = false;
        //controllerMusic.StopMusicMenuPause();
        //controllerMusic.ActiveMusicGameplay();
        pause.SetActive(false);
        game.SetActive(true);
        background.SetActive(true);
        Time.timeScale = 1f; // Reanuda el tiempo
    }
        private void OnDestroy()  
    {
        // Botones del menu de pausa
        btnContinue.onClick.RemoveListener(OnContinueButtonClicked);
        btnSettings.onClick.RemoveListener(OnSettingsButtonClicked);
        btnCreditts.onClick.RemoveListener(OnCredittsButtonClicked);
        btnExit.onClick.RemoveListener(OnExitButtonClicked);
    }

    //Botones del Menu Pausa
    private void OnContinueButtonClicked() 
    { Reanudar();}   
    private void OnSettingsButtonClicked() 
    {
        pause.SetActive(false);
        settingsPanel.SetActive(true);
    }
    private void OnCredittsButtonClicked()
    {
        pause.SetActive(false);
        credittsPanel.SetActive(true);
    }
    private void OnExitButtonClicked() 
    {
        Application.Quit();
#if UNITY_EDITOR && !UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
    }
}