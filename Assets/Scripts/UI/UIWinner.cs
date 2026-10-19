using TMPro;
using UnityEngine;

public class UIWinner : MonoBehaviour
{
    public static UIWinner Instance { get; private set; }

    [SerializeField] private GameObject winnerPanel;
    [SerializeField] private TextMeshProUGUI scoreTextTotal;

    private bool isWinner = false;
    public bool IsWinner { get { return isWinner; } }
    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        winnerPanel.SetActive(false);
    }

    public void ScoreWinner()
    {
        isWinner = true;
        scoreTextTotal.text = "Score: " + Mathf.Round(UIScore.Instance.Score);
        winnerPanel.SetActive(true);
        AudioManager.Instance.ActiveMusicWin();
        Time.timeScale = 0f;
    }
}