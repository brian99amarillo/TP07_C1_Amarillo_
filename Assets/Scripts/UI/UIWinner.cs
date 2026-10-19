using TMPro;
using UnityEngine;

public class UIWinner : MonoBehaviour
{
    public static UIWinner Instance;
    [SerializeField] private TextMeshProUGUI scoreTextTotal;

    private void Update()
    {
        scoreTextTotal = UIScore.Instance.ScoreText;
        
    }
    public void ScoreWinner() => scoreTextTotal.text = "Score: " + ToString();
}
