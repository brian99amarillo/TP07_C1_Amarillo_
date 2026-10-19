using System;
using TMPro;
using UnityEngine;

public class UIScore : MonoBehaviour
{
    public static UIScore Instance;
    [SerializeField] private float score;
    [SerializeField] private float multoplicationStore = 50f;
    [SerializeField] private TextMeshProUGUI scoreText;

    public TextMeshProUGUI ScoreText { get { return scoreText; } }
    private void Awake()
    {
        Instance = this;
    }
    private void Update()
    {
        score += Time.deltaTime* multoplicationStore;
        scoreText.text = Mathf.Round(score).ToString();
    }
}
