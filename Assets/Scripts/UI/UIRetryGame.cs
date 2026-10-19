using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIRetryGame : MonoBehaviour
{
    [SerializeField] private Button btnRetry;
    [SerializeField] private GameObject panelGameOver;
    //[SerializeField] private ControllerMusic controllerMusic;

    private void Awake()
    {
        btnRetry.onClick.AddListener(OnRetryButtonClicked);
    }

    private void OnDestroy()
    {
        btnRetry.onClick.RemoveListener(OnRetryButtonClicked);
    }

    private void OnRetryButtonClicked()
    {
        panelGameOver.SetActive(false);
        SceneManager.LoadScene("Game");
        Time.timeScale = 1f;

    }
}