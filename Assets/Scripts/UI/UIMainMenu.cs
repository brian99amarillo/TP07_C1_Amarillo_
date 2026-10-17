using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIMainMenu : MonoBehaviour
{

    [Header("Menu Pause Buttons")]
    [SerializeField] private Button btnPlay;        
    [SerializeField] private Button btnSettings;   
    [SerializeField] private Button btnCreditts;    
    [SerializeField] private Button btnExit;        

    [Header("Panels & Scenes")]
    [SerializeField] private GameObject Menu;
    [SerializeField] private GameObject SettingsPanel;
    [SerializeField] private GameObject CredittsPanel;

    private void Awake()  
    {
        // Botones del menu principal
        btnPlay.onClick.AddListener(OnPlayButtonClicked);
        btnSettings.onClick.AddListener(OnSettingsButtonClicked);
        btnCreditts.onClick.AddListener(OnCredittsButtonClicked);
        btnExit.onClick.AddListener(OnExitButtonClicked);
    }

    private void Start()
    {
        Time.timeScale = 1f;
    }
    private void OnDestroy()  
    {
        // Botones del menu de pausa
        btnPlay.onClick.RemoveListener(OnPlayButtonClicked);
        btnSettings.onClick.RemoveListener(OnSettingsButtonClicked);
        btnCreditts.onClick.RemoveListener(OnCredittsButtonClicked);
        btnExit.onClick.RemoveListener(OnExitButtonClicked);
    }

    private void OnPlayButtonClicked()  
    {
        SceneManager.LoadScene("Gameplay");     
    }
    private void OnSettingsButtonClicked() 
    {
        Menu.SetActive(false);
        SettingsPanel.SetActive(true);
    }
    private void OnCredittsButtonClicked() 
    {
        Menu.SetActive(false);
        CredittsPanel.SetActive(true);
    }
    private void OnExitButtonClicked() 
    {
     Application.Quit();
#if UNITY_EDITOR && !UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
    }
}
