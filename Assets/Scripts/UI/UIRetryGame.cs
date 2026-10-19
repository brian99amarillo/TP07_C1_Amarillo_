using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIRetryGame : MonoBehaviour
{
    [SerializeField] private Button btnRetry;
    [SerializeField] private string sceneName = "Gameplay";

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
        Time.timeScale = 1f;
        SceneManager.LoadScene(sceneName);
    }
}